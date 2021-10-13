using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Movement.UP)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (moveSpeed*Time.deltaTime), transform.position.z);
        }
        
        if (Movement.DOWN)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - (moveSpeed*Time.deltaTime), transform.position.z);
        }
        if (Movement.LEFT)
        {
            transform.position = new Vector3(transform.position.x - (moveSpeed*Time.deltaTime), transform.position.y , transform.position.z);
        }
        if (Movement.RIGHT)
        {
            transform.position = new Vector3(transform.position.x + (moveSpeed*Time.deltaTime), transform.position.y , transform.position.z);
        }
    
    }

   
}
