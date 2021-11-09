using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class DamageNumber : MonoBehaviour
{
    public TextMeshProUGUI number;

    public float speed;
    public float lifetime;
    public Vector3 offset;
    private bool _started = false;
    
    
    public void Inicializar(float dmg, Transform reference)
    {
        gameObject.transform.position = reference.position + offset + (Vector3) Random.insideUnitCircle * 0.5f;
        _started = true;
        number.text = dmg.ToString(CultureInfo.CurrentCulture);
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        if (_started)
        {
            gameObject.transform.position += new Vector3(0, 1, 0) * (speed * Time.deltaTime);
        }
    }
}
