using System;
using ScriptableObjects;
using UnityEngine;

public static class IsometricUtils
{
    private const float CellSizeY = 0.5f;
    public static Vector2 CartesianToIsometric(Vector2 input)
    {
        return new Vector2(input.x - input.y , -(-input.x - input.y )/2 );
    }

    public static Vector2 PolarToCartesian(float angle, float distance)
    {
        return new Vector2(distance * (float) Math.Cos((Math.PI / 180) * angle), distance * (float )Math.Sin((Math.PI / 180)*angle));
    }

    public static float CalculateDamage(float weaponDmg, float chrStrength, Elements.Element elementWeapon, Elements.Element elementObjetive)
    {
        float elementMultiplier = Elements.GetElementMultiplier(elementWeapon, elementObjetive);
        Debug.Log("Dmg base: " + (weaponDmg + chrStrength) +"Multiplicador de elemento: "  + elementMultiplier + "(" + elementWeapon.ToString() + " => " + elementObjetive.ToString() + ")");
        return (weaponDmg + chrStrength) * elementMultiplier;
    }

    public static Vector3 CoordinatesToWorldSpace(float x, float y)
    {
        Debug.Log(x + " " + y);
        return  CartesianToIsometric(new Vector2(x/2, y/2*CellSizeY));
    }
}
