using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootCooldown : MonoBehaviour
{
    [SerializeField] Slider _shootCooldown;
    [SerializeField] Gun _gunScript;

    private void Start()
    {
        _shootCooldown.value = 0;
    }

    private void Update()
    {
        if (_gunScript.isAming)
        {
            _shootCooldown.value = _gunScript.ShootColdownTime();
        }
       
    }
}
