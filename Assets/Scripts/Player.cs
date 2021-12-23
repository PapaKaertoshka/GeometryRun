using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class Player : MonoBehaviour
{
    
    [SerializeField] private Pl[] types;
    [SerializeField] private GameObject[] shapes;
    [SerializeField] private bool invincibility;
    public int type, typeNow;
    [SerializeField] private TextMesh text;
    public void Start()
    {
        text.text = types[typeNow].Text;
        gameObject.GetComponent<MeshFilter>().mesh = types[typeNow].Mesh;
        gameObject.GetComponent<MeshRenderer>().material = types[typeNow].Material;
        gameObject.transform.localScale = types[typeNow].Scale;
    }
    IEnumerator Invincibility()
    {
        invincibility = true;
        yield return new WaitForSeconds(3f);
        invincibility = false;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Shape shape))
        {
            if (shape.typeNow == typeNow)
            {
                typeNow++;
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.tag == "Wall")
        {
            if (collision.gameObject.TryGetComponent(out Wall wall))
            {
                if (typeNow - wall.type >= 0)
                {
                    typeNow -= wall.type;
                    Destroy(collision.gameObject);
                }
                else if (typeNow - wall.type < 0)
                {
                    SceneManager.LoadScene("Main");
                }
            }
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Obstacle" || other.gameObject.tag == "Tube") && invincibility == false)
        {
            StartCoroutine(Invincibility());
            typeNow--;
            if (typeNow < 0)
            {
                SceneManager.LoadScene("Main");
            }
        }
        if (other.gameObject.TryGetComponent(out Saw saw) && invincibility == false)
        {
            typeNow--;
            Instantiate(shapes[typeNow], new Vector3(transform.position.x + transform.localScale.x, transform.position.y, transform.position.z - 0.2f), Quaternion.identity);
            StartCoroutine(Invincibility());
        }
    }
    public void Update()
    {
        if(type != typeNow)
        {
            text.text = types[typeNow].Text;
            gameObject.GetComponent<MeshFilter>().mesh = types[typeNow].Mesh;
            gameObject.GetComponent<MeshRenderer>().material = types[typeNow].Material;
            gameObject.transform.localScale = types[typeNow].Scale;
            type = typeNow;
        }
    }

}
