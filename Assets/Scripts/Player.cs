using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] private GameObject[] types;
    [SerializeField] public int type, typeNow;
    [SerializeField] private PlayerShape playerShape;
    public void Start()
    {
        types[typeNow].SetActive(true);
        if (types[typeNow].TryGetComponent(out PlayerShape ps)) playerShape = ps;
    }
    public void Update()
    {
        if(type != typeNow)
        {
            types[type].SetActive(false);
            types[typeNow].SetActive(true);
            type = typeNow;
        }
    }

}
