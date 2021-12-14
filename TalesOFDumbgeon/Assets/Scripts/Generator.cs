using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Generator : MonoBehaviour
{
    public int tilesArea;
    public int difficulty;
    [NonSerialized] public MapInstance Map;
    [NonSerialized] private int _numEnemys;
    [NonSerialized] private bool[] _index;
    [NonSerialized] private int _generated = 0;
    public void InstantiateEnemys(List<BaseEnemy> enemys)
    {
        
        int reaminingDiff = difficulty;
        _numEnemys = 0;
        while (reaminingDiff>0)
        {
            int count = 10;
            BaseEnemy enemy;
            do
            {
                
                enemy = enemys[Random.Range(0, enemys.Count)];
                Debug.Log(count + " " + enemy.ToString());
                count--;
            } while (reaminingDiff - enemy.difficulty < 0 && count > 0);
            //Debug.Log("Checking count");
            if (count <= 0)
                break;
            //Debug.Log("Generating enemy");
            Vector2 tilePos = IsometricUtils.ScreenCordsToTilesPos(gameObject.transform.position, false);
            Vector2 newTilePos = new Vector2(tilePos.x + Random.Range((float) -tilesArea, tilesArea),
                tilePos.y + Random.Range((float) -tilesArea, tilesArea));
            //Debug.Log(newTilePos);
            reaminingDiff -= enemy.difficulty;
            BaseEnemy newEnemy =Instantiate(enemy, IsometricUtils.CoordinatesToWorldSpace(newTilePos.x, newTilePos.y), Quaternion.identity, this.gameObject.transform);
            Map.enemys.Add(newEnemy.stats);
            _numEnemys++;
        }

        _index = new bool[_numEnemys];
        ChangeCentinel();
    }

    public int GetNumber()
    {
        _generated++;
        return _generated - 1;
        
    }
    public void ChangeCentinel()
    {
        int newIndex = Random.Range(0, _numEnemys);
        for (int i = 0; i < _numEnemys; i++)
            _index[i] = (i == newIndex);
    }

    public bool IsCentinel(int idx)
    {
        return _index[idx];
    }

    public int GetNumEnemys()
    {
        return _generated;
    }
}
