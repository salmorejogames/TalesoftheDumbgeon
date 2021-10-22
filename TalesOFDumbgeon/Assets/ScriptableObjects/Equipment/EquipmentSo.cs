using UnityEngine;

namespace ScriptableObjects.Equipment
{
    public class EquipmentSo : ScriptableObject
    {
        public enum EquipmentType
        {
            Weapon,
            Magic,
            Head,
            Body,
            Feet
        }

        public EquipmentType type;
        public float strength;
        public float armor;
        public float speed;
        public Elements.Element element;
        

        public virtual void Equip(CharacterStats stats)
        {
            int pos = (int) type;
            if(stats.equipment[pos]!=null)
                stats.equipment[pos].Unequip(stats);
            stats.equipment[pos] = this;
            stats.armor += armor;
            stats.speed += speed;
            stats.strength += strength;
            if (type == EquipmentType.Body)
                stats.element = element;
        }
        
        public virtual void Unequip(CharacterStats stats)
        {
            stats.equipment[(int) type] = null;
            stats.armor -= armor;
            stats.speed -= speed;
            stats.strength -= strength;
            if (type == EquipmentType.Body)
                stats.element = Elements.Element.Caos;
        }
    }
}
