using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMovement : MonoBehaviour
{
    [Header("Lists")]
    [SerializeField] private List<Transform> players = new List<Transform>();
    [SerializeField] private float[] limits; //0->Left  1->Up  2-> Right  3-> Down
    [Header("Settings")]
    [SerializeField] private Vector3 offset;
    [SerializeField] private float minZoom = 75f;
    [SerializeField] private float maxZoom = 40f;
    //[SerializeField] private float zoomLimiter = 80f;
    private Vector3 velocity;
    private float smoothTime = 0.2f;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (players.Count == 0)
            return;
        //Debug.Log("[1] Late updateeee");
        Move();
        //Zoom();
        limitsAplication();
    }

   

    private void Move()
    {
        Vector3 newPos = getCenterPoint() + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
        //Debug.Log("[2] PASO POR MOVE");
    }

    private void Zoom()
    {
        getGreatestDistance();

        float newZoom = Mathf.Lerp(maxZoom, minZoom, getGreatestDistance() / 50f);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);

    }

    private Vector3 getCenterPoint()
    {
        if (players.Count == 1)
            return players[0].position;
        Bounds b = new Bounds(players[0].position, Vector3.zero);
        foreach (Transform player in players)
        {
            b.Encapsulate(player.position);
        }
        return b.center;
    }

    private float getGreatestDistance()
    {
        Bounds b = new Bounds(players[0].position, Vector3.zero);
        foreach (Transform player in players)
        {
            b.Encapsulate(player.position);
        }
        return b.size.x;
    }

    private void limitsAplication()
    {
        //Debug.Log(transform.position);
        if (transform.position.x <= limits[0]) //Left
        {
            transform.position = new Vector3(limits[0],transform.position.y, transform.position.z);
        }
        else if(transform.position.x >= limits[2]) //Right
        {
            transform.position = new Vector3(limits[2], transform.position.y, transform.position.z);
        }
        if (transform.position.y <= limits[3]) //Down
        {
            transform.position = new Vector3(transform.position.x, limits[3], transform.position.z);
        }
        else if(transform.position.y >= limits[1]) //Up
        {
            transform.position = new Vector3(transform.position.x, limits[1], transform.position.z);
        }       
    }
}
