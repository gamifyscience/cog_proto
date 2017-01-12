using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomUtils
{
    // Uses a gaussian distribution to get a random number.
    public static float GetGaussian(float mean, float stdDeviation)
    {
        float u1 = Random.Range(0f, 1f);
        float u2 = Random.Range(0f, 1f);
        float randStdNormal = Mathf.Sqrt(-2f * Mathf.Log(u1)) *
                   Mathf.Sin(2f * Mathf.PI * u2); //random normal(0,1)
        float randNormal =
                     mean + stdDeviation * randStdNormal; //random normal(mean,stdDev^2)

        return randNormal;
    }

    public static Vector3 GetNormalizedVector()
    {
        float x = GetGaussian(0f, 1f);
        float y = GetGaussian(0f, 1f);
        float z = GetGaussian(0f, 1f);

        return new Vector3(x, y, z).normalized;
    }
}