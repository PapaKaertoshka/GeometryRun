using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Mash&Material")]
public class Pl : ScriptableObject
{
    [field: SerializeField]
    public Mesh Mesh
    {
        get;
        private set;
    }

    [field: SerializeField]
    public Material Material
    {
        get;
        private set;
    }
    [field:SerializeField]
    public Vector3 Scale
    {
        get;
        private set;
    }
    [field: SerializeField]
    public string Text
    {
        get;
        private set;
    }

}

