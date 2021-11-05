using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Equipment;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    //public static int MaxMaps;
    //public static int ActualMap;
    
    //[SerializeField] private List<MapInstance> maps;
    [SerializeField] private float playerRelativeSpeed;
    [SerializeField] private float sleepTime;
    [SerializeField] private int tilesMovedInTransition;
    private IsometricMove _player;
    private MapInstance _actualMap;
    private MapInstance _oldMap;
    private Camera _mainCamera;
    private ProceduralDungeon _dungeon;
    public float transitionSpeed;
    private Vector2 _mod;

    private int _actualX;
    private int _actualY;
    private void Awake()
    {
        _mod = Vector2.zero;
        _dungeon = FindObjectOfType<ProceduralDungeon>();
        //_actualMap = Instantiate(maps[0], Vector3.zero, Quaternion.identity);
        //_actualMap.StartMap();
        //MaxMaps = maps.Count;
        //ActualMap = 0;
    }

    private void Start()
    {
        _actualX = _dungeon.InitialPos.x;
        _actualY = _dungeon.InitialPos.y;
        _actualMap = _dungeon.GetRoom(_actualX, _actualY);
        _actualMap.gameObject.SetActive(true);
        _actualMap.StartMap();
        ReloadScene();
    }

    
    public void InstantiateMap()
    {
        Debug.Log("Instantiate Map");

        float xPos = 0;
        float yPos = 0;
        _mod.x = 1;
        _mod.y = 1;
        MapInstance newMapInstance;
        Vector3 pos = _player.gameObject.transform.position;
        
        if (pos.x <= 0 && pos.y <= 0)
        {
            _actualY--;
            newMapInstance = _dungeon.GetRoom(_actualX, _actualY);
            newMapInstance.gameObject.SetActive(true);
            _mod.x = -1;
            _mod.y = 0;
            Debug.Log("SOUTH");
            xPos = _actualMap.dims[1] - newMapInstance.dims[0];
        }else if (pos.x <= 0 && pos.y >= 0)
        {
            _actualX--;
            newMapInstance = _dungeon.GetRoom(_actualX, _actualY);
            newMapInstance.gameObject.SetActive(true);
            Debug.Log("WEST");
            _mod.x = 0;
            yPos = _actualMap.dims[2] - newMapInstance.dims[3];
            
        }else if (pos.x >= 0 && pos.y >= 0)
        {
            _actualY++;
            newMapInstance = _dungeon.GetRoom(_actualX, _actualY);
            newMapInstance.gameObject.SetActive(true);
            Debug.Log("NORTH");
            _mod.y = 0;
            xPos = _actualMap.dims[0] - newMapInstance.dims[1];
        }
        else
        {
            _actualX++;
            newMapInstance = _dungeon.GetRoom(_actualX, _actualY);
            newMapInstance.gameObject.SetActive(true);
            _mod.x = 0;
            _mod.y = -1;
            yPos = (_actualMap.dims[3] - newMapInstance.dims[2]);
        }

        
        //Debug.Log(_actualMap.Dimensions.ToString() + " " + newMapInstance.Dimensions.ToString() + " "  + multiplier);
        //float newX = _mod.x*(_actualMap.Dimensions.x/4 + newMapInstance.Dimensions.x/4);
        //float newY = _mod.y*(_actualMap.Dimensions.y*IsometricUtils.CellSizeY/4 + newMapInstance.Dimensions.y*IsometricUtils.CellSizeY/4);
        //float xPos = _mod.x*(_actualMap.Dimensions.x/2 + newMapInstance.Dimensions.x/2)*0.5f;
        //float yPos = _mod.y * (_actualMap.Dimensions.y / 2 + newMapInstance.Dimensions.y / 2)*0.5f;
        //float xPos = _actualMap
        Debug.Log("NEW MAP COORDS: " + xPos + " " + yPos);
        Vector3 newCenter = IsometricUtils.CoordinatesToWorldSpace(xPos, yPos);
        newMapInstance.gameObject.transform.position = newCenter;
        _oldMap = _actualMap;
        newMapInstance.gameObject.SetActive(true);
        _actualMap.SetCollisions(false);
        newMapInstance.SetCollisions(false);
        _actualMap = newMapInstance;
        StartCoroutine("Transition", newCenter);
        
    }

    private Vector3 CalculatePlayerRelativeCoordinates()
    {
        return (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(tilesMovedInTransition*_mod.x, tilesMovedInTransition*_mod.y));
    }
    private IEnumerator Transition(Vector3 destiny)
    {
        var cameraTr = _mainCamera.gameObject.transform.position;
        var playerPos = _player.gameObject.transform.position;
        var coordinates = CalculatePlayerRelativeCoordinates();
 
        Vector3 cameraDestiny = new Vector3(destiny.x, destiny.y, cameraTr.z);
        Vector3 playerObjetive = playerPos + coordinates;
        SingletoneGameController.PlayerActions.DisableMovement();
        yield return new WaitForSeconds(sleepTime);
        _player.UpdateAngle(coordinates);
        while (Vector3.Distance(playerPos, playerObjetive)>0.001)
        {
            playerPos = Vector3.MoveTowards(playerPos, playerObjetive, _player.Stats.speed*playerRelativeSpeed*Time.deltaTime);
            _player.transform.position = playerPos;
            yield return null;
        }
        while(Vector3.Distance(cameraTr, cameraDestiny) > 0.001)
        {
            cameraTr = Vector3.MoveTowards(cameraTr, cameraDestiny, transitionSpeed*Time.deltaTime);
            _mainCamera.gameObject.transform.position = cameraTr;
            yield return null;
        }
        AfterTransition(destiny);
    }

    private void AfterTransition(Vector3 actualPos)
    {
        //Destroy(_oldMap.gameObject);
        _oldMap.gameObject.SetActive(false);
        _actualMap.transform.position = Vector3.zero;
        _mainCamera.transform.position = new Vector3(0, 0, _mainCamera.transform.position.z);
        _player.transform.position = _player.transform.position - actualPos;
        SingletoneGameController.PlayerActions.EnableMovement();
        _actualMap.StartMap();
    }
    public void ReloadScene()
    {
        _player = FindObjectOfType<IsometricMove>();
        _mainCamera = Camera.main;
    }

    public void NextMap()
    {
        InstantiateMap();
    }

    
}
