using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthPoints))]
[RequireComponent(typeof(GunFireScript))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 direction;
    public Vector3 GetDirection()
    {
        return direction;
    }
    public Transform GetPlayerTransform()
    {
        return transform;
    }

    private GunFireScript gunScript;
    public Transform barrelPos;
    public GameObject hud;
    private WeaponUIScript weaponHudScript;


    //Ammo
    public int ammoCount;
    public int ammoSize;

    

    void Start()
    {
        gunScript = GetComponent<GunFireScript>();
        weaponHudScript = hud.GetComponent<WeaponUIScript>();
        ammoSize = 40;
        ammoCount = ammoSize;
        weaponHudScript.UpdateInfo(ammoSize, ammoCount);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (  ammoCount >=1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            ammoCount--;
            gunScript.Shoot(barrelPos);
            weaponHudScript.UpdateInfo(ammoSize,ammoCount);

        }
    }
}
