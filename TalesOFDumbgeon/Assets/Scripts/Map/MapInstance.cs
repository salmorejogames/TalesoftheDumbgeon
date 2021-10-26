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
    [SerializeField] private CompositeCollider2D mapTrigger;
    private TilemapRenderer _triggerRenderer;
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private List<GameObject> powerUpList;
    [NonSerialized] public List<CharacterStats> enemys;
    private bool doors = false;
    private void Awake()
    {
        ground.CompressBounds();
        Dimensions = (Vector2Int) ground.size;
        enemys = new List<CharacterStats>();
        _triggerRenderer = mapTrigger.gameObject.GetComponent<TilemapRenderer>();
    }

    private void Update()
    {
        CheckAlive();
        if (enemys.Count <= 0 && !doors)
        {
            OpenDors(true);
        }
    }

    /**
     * True-> Open the door
     * False-> Close the door
     */
    private void OpenDors(bool open)
    {
        SetTrigger(open);
        SetTriggerRenderers(!open);
        doors = open;
    }

    public void StartMap()
    {
        //Debug.Log(collisions.GetTile(Vector3Int.zero));
        Debug.Log("Starting Map");
        SetCollisions(true);
        for (int i = 0; i < enemyList.Count ; i++)
        {
            Debug.Log("Genrating Enemy " + i);
            int xx;
            int yy;
            do
            {
                xx = Random.Range((-Dimensions.x + 3) / 2, (Dimensions.x - 2) / 2);
                yy = Random.Range((-Dimensions.y + 3) / 2, (Dimensions.y - 2) / 2);
            } while (!IsValidPosition(xx, yy));
            var newEnemy = Instantiate(enemyList[i], gameObject.transform, true);
            newEnemy.transform.position = IsometricUtils.CoordinatesToWorldSpace(xx, yy);
            newEnemy.transform.localScale = new Vector3(1, 1, 1);
            enemys.Add(newEnemy.GetComponent<CharacterStats>());
        }
        for (int i = 0; i < powerUpList.Count ; i++)
        {
            int xx;
            int yy;
            do
            {
                xx = Random.Range((-Dimensions.x + 3) / 2, (Dimensions.x - 2) / 2);
                yy = Random.Range((-Dimensions.y + 3) / 2, (Dimensions.y - 2) / 2);
            } while (!IsValidPosition(xx, yy));
            var newPowerUp = Instantiate(powerUpList[i], gameObject.transform, true);
            newPowerUp.transform.position = IsometricUtils.CoordinatesToWorldSpace(xx, yy);
            newPowerUp.transform.localScale = new Vector3(1, 1, 1);
        }
        
        OpenDors(false);
    }

    private void CheckAlive()
    {
        for (int i = enemys.Count-1; i>=0; i--)
        {
            var stats = enemys[i];
            if (!stats.IsAlive())
                enemys.Remove(stats);
        }
    }

    private bool IsValidPosition(int x, int y)
    {
        Vector3Int pos = new Vector3Int(x, y, 0);
        if(ground.GetTile(pos)!=null && collisions.GetTile(pos)==null)
            return true;
        return false;
    }
    public void SetTrigger(bool active)
    {
        Debug.Log("SetTrigger: " + active );
        mapTrigger.isTrigger = active;
       
    }

    public void SetCollisions(bool active)
    {
        //mapTrigger.enabled = active;
        _triggerRenderer.GetComponent<TilemapCollider2D>().enabled = active;
    }

    public void SetTriggerRenderers(bool active)
    {
        _triggerRenderer.enabled = active;
        
    }
    
}
