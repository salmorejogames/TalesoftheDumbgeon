using UnityEngine;

namespace Cards.CardsActions
{
    [CreateAssetMenu(fileName = "New Card", menuName = "Cards/Effects/Health")]
    public class SetHealth : CardEffect
    {
        public enum Objetivo
        {
            Jugador
        }
        public int cantidad;
        public Objetivo objetivo;
        public Elements.Element element;
        
        public override void Start()
        {
            switch (objetivo)
            {
                case Objetivo.Jugador:
                    if(cantidad>0)
                        SingletoneGameController.PlayerActions.Healh(cantidad);
                    else
                        SingletoneGameController.PlayerActions.Damage(cantidad, element);
                    break;
            }
        }
    }
}
