using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crystals : MonoBehaviour
{
    [SerializeField] private Transform crystals;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            transform.DOMove(crystals.position, 1f);
        }
    }
}
