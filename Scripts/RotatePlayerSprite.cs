using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerSprite : MonoBehaviour
{

    float x = 0;
    float y = 0;
    float z = 0;

    public void SetX(float i)
    {
        x = i;
    }

    public void SetY(float i)
    {
        y = i;
    }

    public void SetZ(float i)
    {
        z = i;
    }

    public void DoRotation()
    {
        transform.rotation = Quaternion.Euler(x, y, z);
    }
}