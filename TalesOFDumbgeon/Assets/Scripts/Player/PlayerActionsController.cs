using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class PlayerActionsController : MonoBehaviour, IDeadable
{
    public Weapon weapon;
    [NonSerialized] public bool invincible;

    [SerializeField] private float inmunityTime;
    [SerializeField] private GameObject movileInterface;
    [SerializeField] private GameObject barraVida;
    [SerializeField] private GameObject habilidades;
    [SerializeField] private GameObject cartas;

    private int _cartaUsada;
    private bool _canAtack = true;
    private bool _canSpell = true;
    private float _distance;

    private CharacterStats _stats;
    private InputControler _controles;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rb;

    [SerializeField] private PostProcessVolume greyscalePostP;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private PlayerAnimationController _playerAnimationController;
    private ColorGrading colorGrading;

    [SerializeField] private GameObject menuGameOver;
    [SerializeField] private GameObject titulo;
    [SerializeField] private GameObject botonReintentar;
    [SerializeField] private GameObject botonSalir;

    [SerializeField] private AudioSource musicaGameOver;
    [SerializeField] private AudioSource musicaGameplay;

    private void Awake()
    {
        _distance = Vector3.Distance(weapon.transform.position, gameObject.transform.position);
        _stats = gameObject.GetComponent<CharacterStats>();
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _controles = new InputControler();
        _controles.Jugador.Atacar.performed += ctx => Atacar();
        _controles.Jugador.Hechizo.performed += ctx => CastSpell();
        _controles.Jugador.Habilidad1.performed += ctx => UsarCarta(1);
        _controles.Jugador.Habilidad2.performed += ctx => UsarCarta(2);
        _controles.Jugador.Habilidad3.performed += ctx => UsarCarta(3);
        _controles.Jugador.Habilidad4.performed += ctx => UsarCarta(4);
        if (CheckIfMobile.isMobile())
        {
            movileInterface.SetActive(true);
        }
        else
        {
            movileInterface.SetActive(false);
        }
    }

    private void Start()
    {
        greyscalePostP.profile.TryGetSettings(out colorGrading);
    }

    // Update is called once per frame
    private void ReactiveAtack()
    {
        _canAtack = true;
        //weapon.GetComponent<Collider2D>().enabled = false;
    }
    
    private void ReactiveSpell()
    {
        _canSpell = true;
    }

    public void UpdateWeaponPosition(float angle)
    {
        weapon.SetOrientation(angle);
        weapon.UpdatePosition(gameObject.transform.position + (Vector3)IsometricUtils.PolarToCartesian(angle, _distance));
    }

    private void Atacar()
    {
        if (_canAtack)
        {
            _playerAnimationController.SetAtacking();
            weapon.Atack();
            _canAtack = false;
            Invoke(nameof(ReactiveAtack), weapon.weaponInfo.AttackSpeed + weapon.AttackDuration);
        }        
    }
    
    private void CastSpell()
    {
        if (_canSpell && weapon.spellInfo!=null)
        {
            Debug.Log("CastingSpell");
            _playerAnimationController.SetSpell();
            weapon.CastSpell();
            _canSpell = false;
            Invoke(nameof(ReactiveSpell), weapon.spellInfo.Cooldown);
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
            _stats.DoDamage(enemyStats.strength, collision.gameObject.transform.position, enemyStats.element);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("TriggerEnter");
        if (other.gameObject.CompareTag("EscenarioTrigger"))
        {
            Debug.Log("Cambiando mapa");
            SingletoneGameController.MapManager.NextMap();
        }

        if (other.gameObject.CompareTag("Collectionable"))
        {
            other.gameObject.GetComponent<ICollectable>().Collect();
        }

        if (other.gameObject.CompareTag("SpellDmg"))
        {
            SpellDmg spell = other.gameObject.GetComponent<SpellDmg>();
            if (spell.OwnerTag != "Player" && !invincible)
            {
                _stats.DoDamage(spell.Amount, spell.Origen, spell.Element);
            }
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
        PlayerPrefsCardSerializer.SaveData(weapon.weaponInfo);
        Greyscale();
        DesactivarMenuGameplay();
        musicaGameplay.Stop();
        menuGameOver.SetActive(true);
        musicaGameOver.Play();
        AnimarMenuGameOver();
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        //Aqui cuando recibe daño Stadnar
        SingletoneGameController.SoundManager.PlaySound("stadtnarrhurt");
        Debug.Log("Damage Recived");
        SingletoneGameController.InterfaceController.UpdateLife(_stats.GetActualHealth() / _stats.maxHealth, _stats.GetActualHealth(),_stats.maxHealth);
        var direction = gameObject.transform.position - enemyPos;
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

    public void AnimarMenuGameOver()
    {
        LeanTween.moveLocalY(titulo, 135, 1.5f).setEaseOutCubic().setDelay(1.5f);
        LeanTween.rotateZ(titulo, -6, 1f).setEaseOutCubic().setDelay(1.5f);

        LeanTween.moveLocalX(botonReintentar, -265, 1.5f).setEaseOutCubic().setDelay(2f);
        LeanTween.moveLocalY(botonReintentar, -200, 1.5f).setEaseOutCubic().setDelay(2f);
        LeanTween.rotateZ(botonReintentar, 3, 1f).setEaseOutCubic().setDelay(2f);

        LeanTween.moveLocalX(botonSalir, 265, 1.5f).setEaseOutCubic().setDelay(2f);
        LeanTween.moveLocalY(botonSalir, -200, 1.5f).setEaseOutCubic().setDelay(2f);
        LeanTween.rotateZ(botonSalir, -5, 1f).setEaseOutCubic().setDelay(2f);
    }

    public void DesactivarMenuGameplay()
    {
        if (CheckIfMobile.isMobile())
        {
            movileInterface.SetActive(false);
        }

        barraVida.SetActive(false);
        habilidades.SetActive(false);
        cartas.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Greyscale()
    {
        colorGrading.saturation.value = -100;
        //mainCamera.orthographicSize = .5f;
    }
}
