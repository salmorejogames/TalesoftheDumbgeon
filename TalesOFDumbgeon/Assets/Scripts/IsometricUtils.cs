using System;
using UnityEngine;

public static class IsometricUtils
{
    public const float CellSizeY = 0.57735f;
    public static Vector2 CartesianToIsometric(Vector2 input)
    {
        return new Vector2(input.x - input.y , -(-input.x - input.y )*CellSizeY );
    }

    public static Vector2 PolarToCartesian(float angle, float distance)
    {
        return new Vector2(distance * (float) Math.Cos((Math.PI / 180) * angle), distance * (float )Math.Sin((Math.PI / 180)*angle));
    }

    public static float CalculateDamage(float dmg, float armor, Elements.Element elementWeapon, Elements.Element elementObjetive)
    {
        float elementMultiplier = Elements.GetElementMultiplier(elementWeapon, elementObjetive);
        Debug.Log("Dmg base: " + (dmg - armor) +"Multiplicador de elemento: "  + elementMultiplier + "(" + elementWeapon.ToString() + " => " + elementObjetive.ToString() + ")");
        float baseDmg = (dmg - armor) * elementMultiplier;
        return baseDmg > 1 ? baseDmg : 1;
    }

    public static Vector3 CoordinatesToWorldSpace(float x, float y)
    {
        //Debug.Log(x + " " + y);
        return  CartesianToIsometric(new Vector2(x/2, y/2));
    }

    public static Vector2 ScreenCordsToTilesPos(Vector2 screenPos, bool index)
    {

        float x = (screenPos.x + screenPos.y / CellSizeY);
        float y = (-screenPos.x + screenPos.y / CellSizeY);
        if (index)
            return new Vector2(Mathf.Floor(x), Mathf.Floor(y));
        else
            return new Vector2(x, y);
    }
    
    public static Vector2 AxisToIsometric(Vector2 axis)
    {
        //Debug.Log(axis.ToString());
        if (axis.y > -0.1f && axis.y < 0.1f && axis.x < 0.1f && axis.x > -0.1f)
            return new Vector2(0, 0);
        if (axis.x > 0.8f && axis.y < 0.2f && axis.y > -0.2f)
            return new Vector2(1, 0);
        if (axis.x < -0.8f && axis.y < 0.2f && axis.y > -0.2f)
            return new Vector2(-1, 0);
        if (axis.y > 0.8f && axis.x < 0.2f && axis.x > -0.2f)
            return new Vector2(0, 1);
        if (axis.y < -0.8f && axis.x < 0.2f && axis.x > -0.2f)
            return new Vector2(0, -1);
        if (axis.x > 0)
        {
            if (axis.y > 0)
            {
                axis.x = 1;
                axis.y = 0;
            }
            else
            {
                axis.x = 0;
                axis.y = -1;
            }
        }
        else{
            if (axis.y > 0)
            {
                axis.x = 0;
                axis.y = 1;
            }
            else
            {
                axis.x = -1;
                axis.y = 0;
            }
        }
        return CartesianToIsometric(axis);
    }
}
