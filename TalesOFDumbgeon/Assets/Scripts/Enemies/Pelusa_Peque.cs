using System;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pelusa_Peque : BaseEnemy, IDeadable
{
    //IDeadable 
    [SerializeField] private SpriteRenderer spr;
    private NavMeshAgent _navMeshAgent;

    [SerializeField]
    private DamageNumber DmgPrefab;

    public float speed = 0.1f;
    public Transform player;


    Pelusa_Peque(Transform player, GameObject padre, CharacterStats padreInfo)
    {
        this.player = player;
    }

    private void Awake()
    {
        stats = gameObject.GetComponent<CharacterStats>();
        _navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        spr.color = SingletoneGameController.InfoHolder.LoadColor(stats.element);
        //padreInfo = padre.GetComponent<CharacterStats>();
        //dmg = padreStats.damage;
        //elemento = padreInfo.element;
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponentInParent<GameObject>() != null)
           // transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        /*else
            Destroy(gameObject);*/
        _navMeshAgent.destination = player.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(5, this.transform.position, Elements.Element.Caos);            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(5, this.transform.position, Elements.Element.Caos);
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        float multiplier = Elements.GetElementMultiplier(element, stats.element);
        DamageNumber dmgN = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        if (multiplier > 1.1f)
            spr.color = Color.red;
        else if (multiplier < 0.9f)
            spr.color = Color.cyan;
        else
            spr.color = Color.yellow;
        dmgN.number.color = spr.color;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        spr.color = Color.white;
    }
}
