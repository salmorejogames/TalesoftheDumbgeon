using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelusa_Peque : MonoBehaviour
{
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
        padreInfo = padre.GetComponent<CharacterStats>();
        dmg = padreStats.damage;
        elemento = padreInfo.element;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponentInParent<GameObject>() != null)
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        else
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            collision.gameObject.GetComponent<CharacterStats>().DoDamage(dmg, this.transform.position, elemento);
            
        }
    }

}
