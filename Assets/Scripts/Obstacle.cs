using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(0f,0f,1f);
    }
}
