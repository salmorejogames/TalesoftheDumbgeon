using System.Collections;
using ScriptableObjects.Equipment;
using UnityEngine;

namespace ScriptableObjects
{
    
    
    public abstract class WeaponSO : EquipmentSo
    {
        public Sprite artwork;
        public float dmg;
        public float attackSpeed;
        public float attackDuration;
        
        public abstract void Atacar(Weapon weaponGO);

       
    }

    
}
