using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCard : BaseCard
{
    // Start is called before the first frame update
    public BaseWeapon Weapon;
    public Weapon Caster;
    
    public WeaponCard()
    {
        //Make it random 
        Weapon = new AreaWeapon();
        Weapon.Randomize(1);
    }

    public WeaponCard(BaseWeapon weapon)
    {
        Weapon = weapon;
    }
    
    public override void CastEffect()
    {
        //Caster.weaponInfo = Weapon;
    }

    public override void Randomize()
    {
        Weapon.Randomize(1);
    }
}
