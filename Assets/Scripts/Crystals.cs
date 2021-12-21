using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Crystals : MonoBehaviour
{
    [SerializeField] private Transform crystals;
    [SerializeField] private Counter text;
    private IEnumerator Waiting()
    {
        yield return new WaitForSeconds(0.6f);
        text._counter++;
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            transform.DOMove(new Vector3(crystals.position.x,crystals.position.y,crystals.position.z + 8), 0.5f);
            transform.DOScale(crystals.transform.lossyScale, 0.1f);
            StartCoroutine(Waiting());
        }
    }
}
