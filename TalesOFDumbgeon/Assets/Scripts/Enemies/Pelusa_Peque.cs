using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelusa_Peque : MonoBehaviour
{
    public float speed = 0.1f;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }


}
