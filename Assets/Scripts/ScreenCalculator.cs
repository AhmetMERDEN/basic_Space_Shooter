using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenCalculator
{
    static float left;
    static float right;
    static float above;
    static float below;

    /// <summary>
    /// Left coordinate
    /// </summary>
    public static float Left
    {
        get
        {
            return left;
        }
    }

    /// <summary>
    /// Right coordinate
    /// </summary>
    public static float Right
    {
        get
        {
            return right;
        }
    }
    /// <summary>
    /// Above coordinate
    /// </summary>
    public static float Above
    {
        get
        {
            return above;
        }
    }
    /// <summary>
    /// Below coordinate
    /// </summary>
    public static float Below
    {
        get
        {
            return below;
        }
    }


    public static void Init()
    {
        float screenZaxis = -Camera.main.transform.position.z;
        Vector3 leftDownCorner = new Vector3(0, 0,  screenZaxis); 
        Vector3 rightUpCorner = new Vector3(Screen.width,Screen.height, screenZaxis);

        Vector3 leftDownCornerGameWorld = Camera.main.ScreenToWorldPoint(leftDownCorner);
        Vector3 rightUpCornerGameWorld = Camera.main.ScreenToWorldPoint(rightUpCorner);

        left = leftDownCornerGameWorld.x;
        right = rightUpCornerGameWorld.x;
        above = rightUpCornerGameWorld.y;
        below = leftDownCornerGameWorld.y;
        
    }
}
