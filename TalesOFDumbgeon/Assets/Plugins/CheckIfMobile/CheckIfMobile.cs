using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CheckIfMobile : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern bool IsMobile();
 
    public static bool isMobile()
    {
#if !UNITY_EDITOR && UNITY_WEBGL
             return IsMobile();
#endif
        return false;
    }
}
