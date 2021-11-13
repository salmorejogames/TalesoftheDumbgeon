using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public AnimationDirection south;
    public AnimationDirection north;
    public AnimationDirection east;
    public AnimationDirection west;

    private const string pathName = "EquipmentClass/";
    // Start is called before the first frame update
    
    void ChangeSprite(AnimationDirection.EquipmentParts part, BodyParts.Sex sex, string equipmentName)
    {
        var equipment = Resources.Load<EquipmentClass>(pathName + equipmentName);
        south.ChangeEquipment(equipment.south, part, sex);
        //north.ChangeEquipment(equipment.north, part, sex);
        //east.ChangeEquipment(equipment.east, part, sex);
        //west.ChangeEquipment(equipment.west, part, sex);
    }
    
    #region Debug

    [ContextMenu("LoadWarriorHead")]
    private void CM_LoadWarrior()
    {
        ChangeSprite(AnimationDirection.EquipmentParts.Head, BodyParts.Sex.Boy, StaticInfoHolder.Warrior);

    }
    
    #endregion
}
