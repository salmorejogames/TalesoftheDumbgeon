using System.Collections.Generic;
using ScriptableObjects.Equipment;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
    public class Enemy : ScriptableObject
    {
        public float maxHealth;
        public float strength;
        public float armor;
        public float speed;
        public Elements.Element element;
        public Sprite sprite;
        public GameObject baseGO;

        public GameObject Instantiate()
        {
            Debug.Log("Instatiate");
            GameObject enemy = Instantiate(baseGO);
            CharacterStats stats = enemy.AddComponent<CharacterStats>();
            stats.speed = speed;
            stats.armor = armor;
            stats.maxHealth = maxHealth;
            stats.strength = strength;
            stats.element = element;
            SpriteRenderer spr = enemy.AddComponent<SpriteRenderer>();
            spr.sprite = sprite;
            spr.sortingLayerName = "H2";
            Collider2D col = enemy.AddComponent<PolygonCollider2D>();
            return enemy;
        }
    }
}
