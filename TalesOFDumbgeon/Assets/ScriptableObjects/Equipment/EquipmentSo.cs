using UnityEngine;

namespace ScriptableObjects.Equipment
{
    public class EquipmentSo : ScriptableObject
    {
        public float strength;
        public float armor;
        public float speed;
        public Elements.Element element;

        public virtual void Equip(CharacterStats stats)
        {
            stats.armor += armor;
            stats.speed += speed;
            stats.strength += strength;
        }
        
        public virtual void Unequip(CharacterStats stats)
        {
            stats.armor -= armor;
            stats.speed -= speed;
            stats.strength -= strength;
        }
    }
}
