using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
  

    public static MapManager Instance;
    [SerializeField] private List<MapInstance> maps;
    private IsometricMove _player;
    private MapInstance actualMap;

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

        actualMap = Instantiate(maps[0], Vector3.zero, Quaternion.identity);

    }

    private void Start()
    {
        ReloadPlayer();
    }

    public void InstantiateMap(int id)
    {
       
        MapInstance newMap = maps[id];
        float newX = (actualMap.dimensions.x + actualMap.dimensions.x * actualMap.gapX)/2;
        float newY = actualMap.dimensions.y/4;
        MapInstance newMapInstance = Instantiate(newMap, (new Vector2(newX, newY)), Quaternion.identity);
        newMapInstance.gameObject.SetActive(true);
        newMapInstance.SetTrigger(false);
        actualMap.SetTrigger(false);
        newMapInstance.TransitionMap(Vector3.zero);
        actualMap.TransitionMap(new Vector2(-newX, -newY));

        //actualMap.gameObject.SetActive(false);
        actualMap = newMapInstance;
        _player.MoveTo(new Vector3(newX - (actualMap.dimensions.x - 2), newY - (actualMap.dimensions.y - 2) / 2, 0), actualMap.transitionSpeed);
    }

    public void ReloadPlayer()
    {
        _player = FindObjectOfType<IsometricMove>();
    }
}
