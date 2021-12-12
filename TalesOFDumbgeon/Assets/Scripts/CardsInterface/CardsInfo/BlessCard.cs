using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessCard : BaseCard
{
    public BaseBlessing Blessing;
    

    public BlessCard(BaseBlessing.BlessingType type)
    {
        cardType = CardType.Bless;
        
        String[] info = new string[2]; // = StaticInfoHolder.LoadName(Weapon.AttackType, Weapon.Element);
        switch (type)
        {
            case BaseBlessing.BlessingType.Heal:
                Blessing = new HealBlessing( SingletoneGameController.PlayerActions.player.Stats);
                switch (((HealBlessing) Blessing).item)
                {
                    case HealBlessing.HealingItems.Chupito:
                        Artwork =  SingletoneGameController.InfoHolder.ChupitoDeLeche;
                        info = StaticInfoHolder.LoadName(Blessing.Type, (int) HealBlessing.HealingItems.Chupito);
                        break;
                    case HealBlessing.HealingItems.Dragon:
                        Artwork =  SingletoneGameController.InfoHolder.GalletasDeDragon;
                        info = StaticInfoHolder.LoadName(Blessing.Type, (int) HealBlessing.HealingItems.Dragon);
                        break;
                    case HealBlessing.HealingItems.Queso:
                        Artwork =  SingletoneGameController.InfoHolder.Queso;
                        info = StaticInfoHolder.LoadName(Blessing.Type, (int) HealBlessing.HealingItems.Queso);
                        break;
                    case HealBlessing.HealingItems.Tortilla:
                        Artwork =  SingletoneGameController.InfoHolder.TortillaDePatatas;
                        info = StaticInfoHolder.LoadName(Blessing.Type, (int) HealBlessing.HealingItems.Tortilla);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                break;
            case BaseBlessing.BlessingType.PowerUp:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        CardName = info[0];
        Description = info[1];
        Strength = Blessing.Strength;
        Armor = Blessing.Armor;
        Speed = Blessing.Speed;
        Health = Blessing.Health;
        CardHolder = SingletoneGameController.InfoHolder.cartaBendicion;
    }
    public override void CastEffect()
    {
        Blessing.Activate();
        SingletoneGameController.SoundManager.PlaySound("bless");
        SingletoneGameController.InterfaceController.UpdateLife();
        //SingletoneGameController.PlayerActions.Heal(Blessing.Health);
    }
    
}
