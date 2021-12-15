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
    IEnumerator Invincibility()
    {
        mainShape.SetInv(true);
        yield return new WaitForSeconds(3f);
        mainShape.SetInv(false);
    }
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
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Obstacle" && mainShape.GetInv() == false)
        {
            mainShape.typeNow--;
            StartCoroutine(Invincibility());
            if (mainShape.typeNow < 0)
            {
                SceneManager.LoadScene("Main");
            }
        }
        if(other.gameObject.tag == "Tube" && mainShape.GetInv() == false){
            mainShape.typeNow--;
            Instantiate(shapes[mainShape.typeNow], new Vector3(transform.position.x - transform.localScale.x, transform.position.y,transform.position.z-0.5f), Quaternion.identity);
            StartCoroutine(Invincibility());
        }
    }
}
