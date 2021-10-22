using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class MapInstance : MonoBehaviour
{
    [NonSerialized] public Vector2Int Dimensions;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap collisions;
    [SerializeField] private Collider2D mapTrigger;
    [SerializeField] private List<Enemy> posibleEnemies;
    [NonSerialized] public List<GameObject> enemys;
    [SerializeField] private int numEnemys; 
    private void Awake()
    {
        ground.CompressBounds();
        Dimensions = (Vector2Int) ground.size;
        enemys = new List<GameObject>();
    }

    public void StartMap()
    {
        Debug.Log(collisions.GetTile(Vector3Int.zero));
        Debug.Log("Starting Map");
        for (int i = 0; i < numEnemys; i++)
        {
            Debug.Log("Genrating Enemy " + i);
            int index = Random.Range(0, posibleEnemies.Count);
            float xx = Random.Range((-Dimensions.x+3)/2, (Dimensions.x-2)/2);
            float yy = Random.Range((-Dimensions.y+3)/2, (Dimensions.y-2)/2);
            var newEnemy = posibleEnemies[index].Instantiate();
            newEnemy.transform.parent = gameObject.transform;
            newEnemy.transform.position = IsometricUtils.CoordinatesToWorldSpace(xx, yy);
            newEnemy.transform.localScale = new Vector3(1, 1, 1);
            enemys.Add(newEnemy);
        }
    }
    
    public void SetTrigger(bool active)
    {
        mapTrigger.enabled = active;
    }
    
}
