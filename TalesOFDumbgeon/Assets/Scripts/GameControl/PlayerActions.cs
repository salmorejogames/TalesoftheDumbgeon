using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using ScriptableObjects.Equipment;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{

    public IsometricMove player;
    private int _movementImpediments;
    
    // Start is called before the first frame update
    void Start()
    {
        ReloadCharacter();
    }
    
    public void ReloadCharacter()
    {
        player = FindObjectOfType<IsometricMove>();
        _movementImpediments = 0;
    }

    public void DisableMovement(float tiempo)
    {
        _movementImpediments++;
        player.canMove = false;
        Invoke(nameof(ReenableMovement), tiempo);
    }

    private void ReenableMovement()
    {
        _movementImpediments--;
        if (_movementImpediments == 0)
            player.canMove = true;
    }

    public void Healh(int cantidad)
    {
        player.Stats.Heal(cantidad);
    }

    public void Damage(int cantidad)
    {
        player.Stats.DoDamage(cantidad);
    }
    public void ChangeEquipment(EquipmentSo newEquipment)
    {
        
        if (newEquipment.type == EquipmentSo.EquipmentType.Weapon)
            player.PlayerActions.weapon.ChangeWeapon((WeaponSO) newEquipment);
        else
            newEquipment.Equip(player.Stats);
        
    }
}
