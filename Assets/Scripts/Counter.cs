using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    public int _counter;
    public TextMeshProUGUI txt;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Crystals crystal))
        {
            _counter++;
            txt.text = _counter.ToString();
            Destroy(other.gameObject);
        }
    }
}
