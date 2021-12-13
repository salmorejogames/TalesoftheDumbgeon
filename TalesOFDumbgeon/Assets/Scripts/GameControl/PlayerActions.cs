using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public IsometricMove player;
    public PlayerAnimationController playerAnimation;
    private int _movementImpediments;
    public bool dead;
    
    // Start is called before the first frame update
    void Start()
    {
        ReloadCharacter();
    }
    
    public void ReloadCharacter()
    {
        player = FindObjectOfType<IsometricMove>();
        playerAnimation = FindObjectOfType<PlayerAnimationController>();
        dead = false;
        _movementImpediments = 0;
    }

    public void Heal(float cantidad)
    {
        player.PlayerActions.Heal(cantidad);
    }
    public void DisableMovement(float tiempo)
    {
        _movementImpediments++;
        player.canMove = false;
        Invoke(nameof(EnableMovement), tiempo);
    }

    public void DisableMovement()
    {
        _movementImpediments++;
        player.canMove = false;
    }

    public void EnableMovement()
    {
        _movementImpediments--;
        if (_movementImpediments == 0)
            player.canMove = true;
    }

    public void Healh(int cantidad)
    {
        player.Stats.Heal(cantidad);
    }

    public void SetWalkAnimation(bool anim)
    {
        player.walkAnimation = anim;
    }

    public void Damage(int cantidad, Elements.Element tipo)
    {
        player.Stats.DoDamage(cantidad, gameObject.transform.position, tipo);
    }
    public void ChangeEquipment(BaseEquipment newEquipment)
    {
        
        if (newEquipment.Type == BaseEquipment.EquipmentType.Weapon)
            player.PlayerActions.weapon.ChangeWeapon((BaseWeapon) newEquipment);
        else
            newEquipment.Equip();
        
    }
}
