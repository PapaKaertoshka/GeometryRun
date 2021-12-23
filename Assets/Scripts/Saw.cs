using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Saw : MonoBehaviour
{
    [SerializeField] Transform wp1, wp2;
    [SerializeField] GameObject saw;
    void Start()
    {
        Sequence sequence = DOTween.Sequence();
        sequence.SetLoops(-1, LoopType.Restart);
        sequence.Append(transform.DOMove(wp2.position, 3f));
        sequence.Append(transform.DOMove(wp1.position, 3f));
        
    }
    private void FixedUpdate()
    {
        saw.transform.Rotate(0, 0, -1f);
    }

}
