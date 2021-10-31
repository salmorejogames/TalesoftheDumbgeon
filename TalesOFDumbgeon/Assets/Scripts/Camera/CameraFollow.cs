using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    const float MAX_DISTANCE = 2f;

    public static bool activeFollow;
    public Transform target; // Specify the player
    public float speed = 1 ;
    public Vector3 offset;
    private Vector3 destination;
    private Vector3 projection;
    
    
    void Start () {
        destination = gameObject.transform.position;
        projection = target.position;
        activeFollow = true;
    }

    void LateUpdate () {
        if (activeFollow)
        {
            if ((target.position - projection).magnitude > MAX_DISTANCE )
            {
                projection = Vector3.MoveTowards(projection, target.position, Time.deltaTime * speed);
                destination = projection;
                //destination.y = transform.position.y;
                transform.position = destination + offset;
            }
        }
        else
        {
            projection = Vector3.zero;
        }

    }
}
