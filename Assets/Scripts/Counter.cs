using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    public int _counter;
    public TextMeshProUGUI txt;
    private void Update()
    {
        txt.text = _counter.ToString();
    }
}
