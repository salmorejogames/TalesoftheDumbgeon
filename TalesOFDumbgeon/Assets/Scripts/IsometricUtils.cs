using System;
using UnityEngine;

public static class IsometricUtils
{
    public static Vector2 CartesianToIsometric(Vector2 input)
    {
        return new Vector2(input.x - input.y , -(-input.x - input.y )/2 );
    }

    public static Vector2 PolarisToCartesian(float angle, float distance)
    {
        return new Vector2(distance * (float) Math.Cos((Math.PI / 180) * angle), distance * (float )Math.Sin((Math.PI / 180)*angle));
    }
}
