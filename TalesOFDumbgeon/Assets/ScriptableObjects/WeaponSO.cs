using System.Collections;
using UnityEngine;

namespace ScriptableObjects
{
    
    [CreateAssetMenu(fileName = "New Weapon", menuName = "Weapons/DefaultWeapon")]
    public class WeaponSO : ScriptableObject
    {
        public Sprite artwork;
        public float angle;
        public float dmg;
        public float attackSpeed;
        public float attackDuration;
        public Elements.Element element;

        public virtual void Atacar(Weapon weaponGO)
        {
            weaponGO.ReactivateCollider(attackDuration);
        }
        

    }
}
