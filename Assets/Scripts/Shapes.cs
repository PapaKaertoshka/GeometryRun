using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shapes : MonoBehaviour
{
    public int typeNow;

    public new int GetType()
    {
        return typeNow;
    }

}
