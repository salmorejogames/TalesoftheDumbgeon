using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Cards/Holder")]
public class CardInfo : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite artwork;
    [SerializeField] private List<CardEffect> effects; 
    public void CastEffect()
    {
        foreach (var effect in effects)
        {
            effect.Start();
        }
    }
}
