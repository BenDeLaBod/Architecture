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


    
   
    [Header("Weapon")]
    public Transform barrelPos;
    private GunFireScript gunScript;
    public GameObject hud;
    private WeaponUIScript weaponHudScript;
    public int ammoCount;
    public int ammoSize;


    [Header("Player Info HUD")]
    //Money
    public int moneyCount;
    private HealthPoints hpScript;
    

    

    void Start()
    {
        gunScript = GetComponent<GunFireScript>();
        hpScript = GetComponent<HealthPoints>();
        weaponHudScript = hud.GetComponent<WeaponUIScript>();
        ammoSize = 40;
        ammoCount = ammoSize;
        weaponHudScript.UpdateInfo(ammoSize, ammoCount);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Shoot();

        //Test take damage HUD Update
        if (Input.GetKeyDown(KeyCode.U))
        {
            hpScript.TakeDamage(3);
        }
      
    }


    /// <summary>
    /// Shoot ability, If player have ammo left and presses Space or Mouse 0 minus 1 ammmo and call
    /// gunScript Shoot method, update players weaponHUD. And for every 6 shoot "Reload" / small delay
    /// </summary>
    private void Shoot()
    {
        if (ammoCount >= 1 && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            ammoCount--;
            if((ammoSize- ammoCount) %6 == 0) 
            {
                Debug.LogError("Reload");
            }

            gunScript.Shoot(barrelPos);
            weaponHudScript.UpdateInfo(ammoSize, ammoCount);

        }
    }

}
