using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment", menuName = "Equipment/EquipmentHolder")]
public class EquipmentClass : ScriptableObject
{
    public BodyParts north;
    public BodyParts south;
    public BodyParts east;
    public BodyParts west;
    public BodyParts nothEast;
    public BodyParts northWest;
    public BodyParts southEast;
    public BodyParts southWest;
}
