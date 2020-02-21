using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Clark_Y
{
    public static float GetCL(float angle)
    {
        if (angle < -6.3)
        {
            return (float)(-0.0333 * angle - 0.72);
        }
        else if (angle < 1.6)
        {
            return (float)(0.129 * angle + 0.303);
        }
        else if (angle < 8)
        {
            return (float)(0.0961 * angle + 0.356);
        }
        else if (angle < 12.4)
        {
            return (float)(0.0341 * angle + 0.852);
        }
        else if (angle < 16.7)
        {
            return (float)(-0.0349 * angle + 1.707);
        }
        else
        {
            float temp = (float)(-0.141 * angle + 3.478);
            return Mathf.Clamp(temp, (float)0.235, (float)1.1092);
        }
    }

    public static float GetCR(float angle)
    {
        if (angle < -4.6)
        {
            return (float)(-0.01759 * angle - 0.05593);
        }
        else if (angle < 13)
        {
            return (float)(0.025);
        }
        else
        {
            return (float)(0.0341 * angle - 0.418);
        }
    }
}
