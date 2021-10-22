using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsController : MonoBehaviour
{
   
    public Weapon weapon;
    public bool active;
    public bool invincible;
    
    private int _cartaUsada;
    private bool _canAtack = true;
    private float _distance;
    [SerializeField] private float inmunityTime;
    
    private GameObject joystick;
    private CharacterStats _stats;
    private InputControler _controles;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _distance = Vector3.Distance(weapon.transform.position, gameObject.transform.position);
        _stats = gameObject.GetComponent<CharacterStats>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        joystick = GameObject.FindGameObjectWithTag("Joystick");
        _controles = new InputControler();
        _controles.Jugador.Atacar.performed += ctx => Atacar();
        _controles.Jugador.Habilidad1.performed += ctx => UsarCarta(1);
        _controles.Jugador.Habilidad2.performed += ctx => UsarCarta(2);
        _controles.Jugador.Habilidad3.performed += ctx => UsarCarta(3);
        _controles.Jugador.Habilidad4.performed += ctx => UsarCarta(4);
    }

    // Start is called before the first frame update
    void Start()
    {
        active = true;
    }

    // Update is called once per frame
    private void ReactiveAtack()
    {
        _canAtack = true;
        weapon.GetComponent<Collider2D>().enabled = false;
        weapon.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    private void Update()
    {
        active = (!weapon.incapacited && !invincible);
    }

    public void UpdateWeaponPosition(float angle)
    {
        weapon.SetOrientation(angle);
        weapon.UpdatePosition(gameObject.transform.position + (Vector3) IsometricUtils.PolarToCartesian(angle, _distance));
    }

    private void Atacar()
    {
        if (_canAtack)
        {
            weapon.Atack();
            _canAtack = false;
            Invoke(nameof(ReactiveAtack), weapon.weaponInfo.attackSpeed);
        }        
    }

    public void UsarCarta(int hueco)
    {
        Debug.Log("Usaste la carta " + hueco);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo") && !invincible)
        {
            CharacterStats enemy_stats = collision.gameObject.GetComponent<CharacterStats>();
            _stats.DoDamage(enemy_stats.strength * Elements.GetElementMultiplier(enemy_stats.element, _stats.element));
            OnDamageReceived(collision.gameObject.transform.position);
            if (!_stats.IsAlive())
            {
                Debug.Log("Im dead");
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EscenarioTrigger"))
        {
            Debug.Log("Cambiando mapa");
            MapManager.Instance.InstantiateMap((MapManager.ActualMap+1)%MapManager.MaxMaps);
        }
    }

    public void OnDamageReceived(Vector3 damagePos)
    {
        Debug.Log("Damage Recived");
        var direction = gameObject.transform.position - damagePos;
        var magnitude = direction.magnitude;
        direction = direction / magnitude;
        _rb.velocity = direction;
        Debug.Log(direction);
        invincible = true;
        _canAtack = false;
        _spriteRenderer.color = Color.red;
        Invoke(nameof(CancelInvincibility), inmunityTime);
        Invoke(nameof(ResetSpriteColor), inmunityTime);
    }

    private void CancelInvincibility()
    {
        _canAtack = true;
        invincible = false;
        _rb.velocity = Vector2.zero;
    }
    
    public void ResetSpriteColor()
    {
        _spriteRenderer.color = Color.white;
    }
    
    private void OnEnable()
    {
        _controles.Enable();
    }

    private void OnDisable()
    {
        _controles.Disable();
    }
}
