using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
  

    public static MapManager Instance;
    [SerializeField] private List<MapInstance> maps;
    [SerializeField] private float gapX;
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
        //Singleton;
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        _mod = Vector2.zero;
        _actualMap = Instantiate(maps[0], Vector3.zero, Quaternion.identity);

    }

    private void Start()
    {
        ReloadScene();
    }

    
    public void InstantiateMap(int id)
    {
        _mod.x = 1;
        _mod.y = 1;
        if (_player.transform.position.x < 0) _mod.x = -1;
        if (_player.transform.position.y < 0) _mod.y = -1;
        
        float newX = _mod.x*(_actualMap.dimensions.x + _actualMap.dimensions.x * gapX)/2;
        float newY = _mod.y*_actualMap.dimensions.y/4;
        Vector3 newCenter = new Vector3(newX, newY, 0);
        MapInstance newMapInstance = Instantiate(maps[id], newCenter, Quaternion.identity);
        _oldMap = _actualMap;
        newMapInstance.SetTrigger(false);
        newMapInstance.gameObject.SetActive(true);
        _actualMap.SetTrigger(false);
        _actualMap = newMapInstance;
        StartCoroutine("Transition", newCenter);
       
    }

    private Vector3 CalculatePlayerRelativeCoordinates()
    {
        if (_mod.x > 0 && _mod.y > 0)
            return (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(tilesMovedInTransition - tilesMovedInTransition*gapX, 0));
        if (_mod.x<0 && _mod.y <0)
            return (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(-tilesMovedInTransition + tilesMovedInTransition*gapX, 0));
        if (_mod.x>0 && _mod.y <0)
            return (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0, -tilesMovedInTransition));
        return (Vector3) IsometricUtils.CartesianToIsometric(new Vector2(0, tilesMovedInTransition));
    }
    private IEnumerator Transition(Vector3 destiny)
    {
        var cameraTr = _mainCamera.gameObject.transform.position;
        var playerPos = _player.transform.position;
        var coordinates = CalculatePlayerRelativeCoordinates();
 
        Vector3 cameraDestiny = new Vector3(destiny.x, destiny.y, cameraTr.z);
        Vector3 playerObjetive = playerPos + coordinates;
        _player.SetActive(false);
        yield return new WaitForSeconds(sleepTime);
        _player.UpdateAngle(coordinates);
        while (Vector3.Distance(playerPos, playerObjetive)>0.001)
        {
            playerPos = Vector3.MoveTowards(playerPos, playerObjetive, _player.speed*playerRelativeSpeed*Time.deltaTime);
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
    }
    public void ReloadScene()
    {
        _player = FindObjectOfType<IsometricMove>();
        _mainCamera = Camera.main;
    }
}
