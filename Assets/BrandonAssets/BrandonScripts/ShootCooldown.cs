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
        
    }

    private void Update()
    {
        _shootCooldown.value = _gunScript.ShootColdownTime();
    }
}
