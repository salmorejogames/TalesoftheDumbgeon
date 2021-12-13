using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageCanvas : MonoBehaviour
{
    public Image spriteRenderer;
    public float speed;
    public float lifetime;
    public Vector3 offset;
    private bool _started = false;

    public void Inicializar(Sprite sprite, Transform reference)
    {
        gameObject.transform.position = reference.position + offset + (Vector3) Random.insideUnitCircle * 0.5f;
        _started = true;
        spriteRenderer.sprite = sprite;
        Destroy(gameObject, lifetime);
    }
    
    void Update()
    {
        if (_started)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * (speed * Time.deltaTime);
        }
    }
    
}
