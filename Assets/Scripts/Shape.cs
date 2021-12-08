using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : Shapes
{
    [SerializeField] private GameObject[] types;
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            if (collision.gameObject.GetType() == gameObject.GetType())
            {
                typeNow++;
                collision.gameObject.SetActive(false);
                types[typeNow].SetActive(true);
                types[typeNow - 1].SetActive(false);
            }
        }
    }
}
