using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Equipment;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    
    public static int MaxMaps;
    public static int ActualMap;
    
    [SerializeField] private List<MapInstance> maps;
    [SerializeField] private float playerRelativeSpeed;
    [SerializeField] private float sleepTime;
    [SerializeField] private int tilesMovedInTransition;
    private IsometricMove _player;
    private MapInstance _actualMap;
    private MapInstance _oldMap;
    private Camera _mainCamera;
    public float transitionSpeed;
    private Vector2 _mod;

    private void Awake()
    {
        _mod = Vector2.zero;
        _actualMap = Instantiate(maps[0], Vector3.zero, Quaternion.identity);
        MaxMaps = maps.Count;
        ActualMap = 0;
    }

    private void Start()
    {
        
        ReloadScene();
    }

    
    public void InstantiateMap(int id)
    {
        Debug.Log("Instantiate Map");

        _mod.x = 1;
        _mod.y = 1;
        Vector3 pos = _player.gameObject.transform.position;
        if (pos.x <= 0 && pos.y <= 0)
        {
            _mod.x = -1;
            _mod.y = 0;
        }else if (pos.x <= 0 && pos.y >= 0)
        {
            _mod.x = 0;
        }else if (pos.x >= 0 && pos.y >= 0)
        {
            _mod.y = 0;
        }
        else
        {
            _mod.x = 0;
            _mod.y = -1;
        }

        MapInstance newMapInstance = Instantiate(maps[id]);
        //Debug.Log(_actualMap.Dimensions.ToString() + " " + newMapInstance.Dimensions.ToString() + " "  + multiplier);
        //float newX = _mod.x*(_actualMap.Dimensions.x/4 + newMapInstance.Dimensions.x/4);
        //float newY = _mod.y*(_actualMap.Dimensions.y*IsometricUtils.CellSizeY/4 + newMapInstance.Dimensions.y*IsometricUtils.CellSizeY/4);
        float xPos = _mod.x*(_actualMap.Dimensions.x/2 + newMapInstance.Dimensions.x/2)*0.5f;
        float yPos = _mod.y * (_actualMap.Dimensions.y / 2 + newMapInstance.Dimensions.y / 2)*0.5f;
        Vector3 newCenter = IsometricUtils.CartesianToIsometric(new Vector2(xPos, yPos));
        newMapInstance.gameObject.transform.position = newCenter;
        _oldMap = _actualMap;
        newMapInstance.SetTrigger(false);
        newMapInstance.gameObject.SetActive(true);
        _actualMap.SetTrigger(false);
        _actualMap = newMapInstance;
        StartCoroutine("Transition", newCenter);
        ActualMap = id;
        

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
        _player.SetActive(false);
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
        Destroy(_oldMap.gameObject);
        _actualMap.transform.position = Vector3.zero;
        _mainCamera.transform.position = new Vector3(0, 0, _mainCamera.transform.position.z);
        _player.transform.position = _player.transform.position - actualPos;
        _actualMap.SetTrigger(true);
        _player.SetActive(true);
        _actualMap.StartMap();
    }
    public void ReloadScene()
    {
        _player = FindObjectOfType<IsometricMove>();
        _mainCamera = Camera.main;
    }

    
}
