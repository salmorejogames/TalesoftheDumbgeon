using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;



public class MapInstance : MonoBehaviour
{

    public enum RoomType
    {
        Big,
        Small,
        Corridor,
        Close,
        Start,
        End
    }
    [Serializable] public struct Orientations
    {
        public bool North;
        public bool South;
        public bool East;
        public bool West;
    }

    public RoomType roomType;
    [SerializeField] public Orientations doorsOrientations;
    [NonSerialized] public Vector2Int Dimensions;
    [NonSerialized] public int[] dims;
    [SerializeField] private Tilemap ground;
    [SerializeField] private Tilemap collisions;
    [SerializeField] private Tilemap doors;
    [SerializeField] private CompositeCollider2D mapTrigger;
    [SerializeField] private List<BaseEnemy> enemyList;
    [SerializeField] private List<GameObject> powerUpList;
    [SerializeField] private List<Generator> generators;
    [NonSerialized] public List<CharacterStats> enemys;
    private bool _closed;
    private bool _started;


    private void Awake()
    {
        _started = false;
        ground.CompressBounds();
        Dimensions = (Vector2Int) ground.size;
        enemys = new List<CharacterStats>();
        dims = new int[4];
        BoundsInt bounds = ground.cellBounds;
        dims[0] = bounds.xMax;
        dims[1] = bounds.xMin;
        dims[2] = bounds.yMax;
        dims[3] = bounds.yMin;
        _closed = true;
        SetTriggerRenderers(false);

    }

    private void Start()
    {
        //enemyList.Sort((a, b) => a.difficulty.CompareTo(b.difficulty));
        BoundsInt bounds = ground.cellBounds;
        //Debug.Log("X: " +bounds.xMax + " " + bounds.xMin+ " Y: " + bounds.yMax + " " + bounds.yMin);
    }

    private void Update()
    {
        CheckAlive();
        if (enemys.Count <= 0 && !_closed)
        {
            OpenDors(true);
            _closed = true;
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
    }

    public void StartMap()
    {
        if (!_started)
        {
            SetCollisions(true);
            SingletoneGameController.NavMeshManager.UpdateNavMesh();
            foreach (var generator in generators)
            {
                generator.map = this;
                generator.InstantiateEnemys(enemyList);
            }
           
            /*
            //Debug.Log(collisions.GetTile(Vector3Int.zero));
            Debug.Log("Starting Map");
            SetCollisions(true);
            for (int i = 0; i < enemyList.Count; i++)
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
            }*/

            for (int i = 0; i < powerUpList.Count; i++)
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
                newPowerUp.transform.localScale = new Vector3(0.1f, 0.1f, 1f);
            }
            
            _started = true;
            OpenDors(false);
        }
        else
        {
            SetCollisions(true);
        }
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
        //Debug.Log("SetTrigger: " + active );
        mapTrigger.isTrigger = active;
       
    }

    public void SetCollisions(bool active)
    {
        //mapTrigger.enabled = active;
        _closed = !active;
        mapTrigger.GetComponent<TilemapCollider2D>().enabled = active;
    }

    public void SetTriggerRenderers(bool active)
    {
        doors.GetComponent<TilemapRenderer>().enabled = active;
    }
    
}
