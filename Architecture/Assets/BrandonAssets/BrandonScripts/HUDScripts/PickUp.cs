using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private IntEventSO _goldEvent;
    [SerializeField] private IntEventSO _damageEvent;
    public int addGoldPickUp = 14;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            _damageEvent.Invoke(-9);
            _goldEvent.Invoke(addGoldPickUp);
            Destroy(gameObject);

        }
    }
}
