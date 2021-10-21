using System.Collections;
using UnityEngine;

namespace ScriptableObjects
{
    
    
    public abstract class WeaponSO : ScriptableObject
    {
        public Sprite artwork;
        public float dmg;
        public float attackSpeed;
        public float attackDuration;

        public Elements.Element element;

        public abstract void Atacar(Weapon weaponGO);

       
    }

    
}
