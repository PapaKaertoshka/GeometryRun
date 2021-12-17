using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShape : MonoBehaviour
{
    [SerializeField] public int typeNow;
    public GameObject[] shapes;
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
        if(collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.TryGetComponent(out Wall wall))
            {
                if (typeNow - wall.type > 0)
                {
                    mainShape.typeNow-=wall.type;
                    Destroy(collision.gameObject);
                }
                else if (typeNow - wall.type <= 0)
                {
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }
}
