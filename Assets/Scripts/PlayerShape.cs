using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShape : MonoBehaviour
{
    [SerializeField] public int typeNow;
    [SerializeField] private Shape otherShape;
    [SerializeField] private Player mainShape;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shape")
        {
            if (collision.gameObject.TryGetComponent(out Shape shape))
            {
                otherShape = shape;
                if (otherShape.typeNow == typeNow)
                {
                    mainShape.typeNow++;
                    Destroy(collision.gameObject);
                }
            }
        }
    }

}
