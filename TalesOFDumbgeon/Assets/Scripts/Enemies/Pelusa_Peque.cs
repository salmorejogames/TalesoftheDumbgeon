using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelusa_Peque : MonoBehaviour, IDeadable
{
    //IDeadable 
    private SpriteRenderer _spr;
    private IsometricMove _player;
    private CharacterStats _stats;

    public int difficulty;

    [SerializeField]
    private DamageNumber DmgPrefab;

    public float speed = 0.1f;
    public Transform player;
    private GameObject padre;
    private Enemigo_Pelusa padreStats;
    private CharacterStats padreInfo;
    private float dmg;
    private Elements.Element elemento;

    Pelusa_Peque(Transform player, GameObject padre, CharacterStats padreInfo)
    {
        this.player = player;
        this.padre = padre;
        this.padreStats = padre.GetComponent<Enemigo_Pelusa>();
        this.padreInfo = padreInfo;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = SingletoneGameController.PlayerActions.player.gameObject.transform;
        dmg = 5f;
        elemento = Elements.Element.Caos;
        //padreInfo = padre.GetComponent<CharacterStats>();
        //dmg = padreStats.damage;
        //elemento = padreInfo.element;
    }

    // Update is called once per frame
    void Update()
    {
        //if (gameObject.GetComponentInParent<GameObject>() != null)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        /*else
            Destroy(gameObject);*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(5, this.transform.position, Elements.Element.Caos);            
        }
    }

    public void Dead()
    {
        gameObject.SetActive(false);
    }

    public void Damage(Vector3 enemyPos, float cantidad, Elements.Element element)
    {
        float multiplier = Elements.GetElementMultiplier(element, _stats.element);
        DamageNumber dmgN = Instantiate(DmgPrefab, transform.position, Quaternion.identity);
        dmgN.Inicializar(cantidad, transform);
        if (multiplier > 1.1f)
            _spr.color = Color.red;
        else if (multiplier < 0.9f)
            _spr.color = Color.cyan;
        else
            _spr.color = Color.yellow;
        dmgN.number.color = _spr.color;
        Invoke(nameof(RevertColor), 0.2f);
    }

    public void RevertColor()
    {
        _spr.color = Color.white;
    }
}
