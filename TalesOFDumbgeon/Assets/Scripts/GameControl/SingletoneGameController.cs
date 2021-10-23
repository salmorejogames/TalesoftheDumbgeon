using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletoneGameController : MonoBehaviour
{
    public static SingletoneGameController Instance;
    public static PlayerActions PlayerActions;
    public static MapManager MapManager;
    public static CardHolder CardHolder;
    private void Awake()
    {
        //Singleton;
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        ReloadComponents();
    }

    public void ReloadComponents()
    {
        MapManager = gameObject.GetComponent<MapManager>();
        PlayerActions = gameObject.GetComponent<PlayerActions>();
        CardHolder = FindObjectOfType<CardHolder>();
    }
    
}
