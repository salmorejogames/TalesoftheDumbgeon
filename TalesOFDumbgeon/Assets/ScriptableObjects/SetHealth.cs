using UnityEngine;

namespace Cards.CardsActions
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards/Effects/Health")]
    public class SetHealth : CardEffect
    {
        public int cantidad;
        public int objetivo;
        public override string Start()
        {
            Debug.Log("Dmg: " + cantidad + "a" + objetivo);
            return "";
        }
    }
}
