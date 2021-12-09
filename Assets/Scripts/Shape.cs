using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shape : MonoBehaviour
{
    [SerializeField] private GameObject[] types;
    [SerializeField] public int typeNow;
/*    [SerializeField] private Shape otherShape;*/
/*    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            otherShape = collision.gameObject.GetComponent<Shape>();
            if (otherShape.typeNow == typeNow)
            {
                typeNow++;
                collision.gameObject.SetActive(false);
                types[typeNow].SetActive(true);
                types[typeNow - 1].SetActive(false);
            }
        }
    }*/
}
