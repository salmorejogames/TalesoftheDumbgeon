using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInstance : MonoBehaviour
{
    public Vector2 dimensions;
    private Vector3 _objetive;
    public float gapX;
    public float transitionSpeed;
    private bool _ready = true;
    [SerializeField] private Collider2D _mapTrigger;

    public bool GetReady()
    {
        return _ready;
    }

    public void TransitionMap(Vector3 objetive)
    {
        _objetive = objetive;
        StartCoroutine(nameof(Transition));
    }

    public void SetTrigger(bool active)
    {
        Debug.Log("Activado: " + active);
        _mapTrigger.enabled = active;
    }

    IEnumerator Transition()
    {
        while(Vector3.Distance(transform.position, _objetive) > 0.001)
        {
            transform.position = Vector3.MoveTowards(transform.position, _objetive, transitionSpeed*Time.deltaTime);
            yield return null;
        }
        _ready = true;
    }
}
