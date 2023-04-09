using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthPoints))]
[RequireComponent(typeof(GunFireScript))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 direction;
    private GunFireScript gunScript;
    public Transform barrelPos;
    public Vector3 GetDirection()
    {
        return direction;
    }
    public Transform GetPlayerTransform()
    {
        return transform;
    }

    void Start()
    {
        gunScript = GetComponent<GunFireScript>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            gunScript.Shoot(barrelPos);
        }
    }
}
