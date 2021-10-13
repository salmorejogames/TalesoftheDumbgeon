using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public static bool UP = false;
    public static bool DOWN = false;
    public static bool LEFT = false;
    public static bool RIGHT = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        UP = false;
        DOWN = false;
        LEFT = false;
        RIGHT = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            UP = true;
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            DOWN = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            LEFT = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            RIGHT = true;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            UP = false;
        }
        
        if (Input.GetKeyUp(KeyCode.S))
        {
            DOWN = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            LEFT = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            RIGHT = false;
        }
    }
    
    public static void SetDirection(int direction)
    {
        switch (direction)
        {
            case 1:
                UP = true;
                break;
            case 2:
                DOWN = true;
                break;
            case 3:
                RIGHT = true;
                break;
            case 4:
                LEFT = true;
                break;
            case -1:
                UP = false;
                break;
            case -2:
                DOWN = false;
                break;
            case -3:
                RIGHT = false;
                break;
            case -4:
                LEFT = false;
                break;
        }
    }
    
    
}
