using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsController : MonoBehaviour
{
    public InputControler controles;
    public Weapon weapon;
    private GameObject joystick;
    private int cartaUsada;
    private bool canAtack = true;
    private float distance;
    private CharacterStats _stats;
    private IsometricMove _isometricMove;

    private void Awake()
    {
        distance = Vector3.Distance(weapon.transform.position, gameObject.transform.position);
        _isometricMove = gameObject.GetComponent<IsometricMove>();
        _stats = gameObject.GetComponent<CharacterStats>();
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        controles = new InputControler();
        controles.Jugador.Atacar.performed += ctx => Atacar();
        controles.Jugador.Habilidad1.performed += ctx => usarCarta(1);
        controles.Jugador.Habilidad2.performed += ctx => usarCarta(2);
        controles.Jugador.Habilidad3.performed += ctx => usarCarta(3);
        controles.Jugador.Habilidad4.performed += ctx => usarCarta(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    private void ReactiveAtack()
    {
        canAtack = true;
        weapon.GetComponent<Collider2D>().enabled = false;
        weapon.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    private void Update()
    {
        float angle = _isometricMove.angle;
        weapon.SetOrientation(angle);
        Vector3 newCenter = gameObject.transform.position + (Vector3) IsometricUtils.PolarToCartesian(angle, distance);
        //newCenter = IsometricUtils.CartesianToIsometric(newCenter);
        weapon.gameObject.transform.position = newCenter;
    }

    private void Atacar()
    {
        if (canAtack)
        {
            weapon.Atack();
            canAtack = false;
            Invoke(nameof(ReactiveAtack), weapon.weaponInfo.attackSpeed);
        }        
    }

    public void usarCarta(int hueco)
    {
        Debug.Log("Usaste la carta " + hueco);
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("colision con " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            CharacterStats enemy_stats = collision.gameObject.GetComponent<CharacterStats>();
            _stats.DoDamage(enemy_stats.damage * Elements.GetElementMultiplier(enemy_stats.element, _stats.element));
        }

        if (!_stats.IsAlive())
        {
            Debug.Log("Im dead");
            Destroy(gameObject);
        }
    }
    
    private void OnEnable()
    {
        controles.Enable();
    }

    private void OnDisable()
    {
        controles.Disable();
    }
}
