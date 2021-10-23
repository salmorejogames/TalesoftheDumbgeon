using ScriptableObjects.Equipment;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards/Effects/ChangeEquipment")]
    public class CardEquipment : CardEffect
    {
        public EquipmentSo equipment;
        public override void Start()
        {
            SingletoneGameController.PlayerActions.ChangeEquipment(equipment);
        }
    }
}