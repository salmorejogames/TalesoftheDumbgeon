using System.Collections;
using System.Collections.Generic;
using Inteface;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingletoneGameController : MonoBehaviour
{
    public static SingletoneGameController Instance;
    public static PlayerActions PlayerActions;
    public static MapManager MapManager;
    public static CardHolder CardHolder;
    public static GameplayInterfaceController InterfaceController;
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
        InterfaceController = FindObjectOfType<GameplayInterfaceController>();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
}
