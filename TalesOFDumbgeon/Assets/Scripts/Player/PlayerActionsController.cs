using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActionsController : MonoBehaviour, IDeadable
{
   
    public Weapon weapon;
    public bool invincible;

    [SerializeField] private float inmunityTime;
    [SerializeField] private GameObject joystick;
    private int _cartaUsada;
    private bool _canAtack = true;
    private float _distance;
  
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
        _controles = new InputControler();
        _controles.Jugador.Atacar.performed += ctx => Atacar();
        _controles.Jugador.Habilidad1.performed += ctx => UsarCarta(1);
        _controles.Jugador.Habilidad2.performed += ctx => UsarCarta(2);
        _controles.Jugador.Habilidad3.performed += ctx => UsarCarta(3);
        _controles.Jugador.Habilidad4.performed += ctx => UsarCarta(4);
        if (CheckIfMobile.isMobile())
        {
            joystick.SetActive(true);
        }
        else
        {
            joystick.SetActive(false);
        }
    }

    // Update is called once per frame
    private void ReactiveAtack()
    {
        _canAtack = true;
        weapon.GetComponent<Collider2D>().enabled = false;
        weapon.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
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
            CharacterStats enemyStats = collision.gameObject.GetComponent<CharacterStats>();
            _stats.DoDamage(enemyStats.strength, collision.gameObject, enemyStats.element);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EscenarioTrigger"))
        {
            Debug.Log("Cambiando mapa");
            SingletoneGameController.MapManager.NextMap();
        }

        if (other.gameObject.CompareTag("Collectionable"))
        {
            other.gameObject.GetComponent<ICollectable>().Collect();
        }
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
    
    public void Dead()
    {
        SingletoneGameController.PlayerActions.dead = true;
        SingletoneGameController.Instance.ChangeScene("GameOverScene");
        Debug.Log("Im dead");
        gameObject.SetActive(false);
        
    }

    public void Damage(GameObject enemy, float cantidad, Elements.Element element)
    {
        Debug.Log("Damage Recived");
        SingletoneGameController.InterfaceController.UpdateLife(_stats.GetActualHealth()/_stats.maxHealth);
        var direction = gameObject.transform.position - enemy.transform.position;
        var magnitude = direction.magnitude;
        direction = direction / magnitude;
        _rb.velocity = direction;
        //Debug.Log(direction);
        invincible = true;
        _canAtack = false;
        _spriteRenderer.color = Color.red;
        SingletoneGameController.PlayerActions.DisableMovement(inmunityTime);
        Invoke(nameof(CancelInvincibility), inmunityTime);
        Invoke(nameof(ResetSpriteColor), inmunityTime);
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
