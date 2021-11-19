using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshManager : MonoBehaviour
{
    private NavMeshSurface2d _surface2d;
    
    
    // Start is called before the first frame update
    void Awake()
    {
        _surface2d = GetComponent<NavMeshSurface2d>();
    }

    public void UpdateNavMesh()
    {
        _surface2d.BuildNavMesh();
    }
    
}
