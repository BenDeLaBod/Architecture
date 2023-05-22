using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject projectilePrefab;
    // public GameObject barrelPosition;

    float shootTimer;
    [SerializeField] private float shootCooldown;

    public GameObject bulletSpawnPoint;

    [SerializeField] private int magSize;
    private int bulletsInMag;

    private BulletManager bulletManager;


    void Start()
    {
        Reload();
        bulletManager = GetComponent<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        if (bulletsInMag > 0 && shootTimer <= 0)
        {
            //Instantiate(projectilePrefab, bulletSpawnPoint.transform.position, transform.rotation);

            bulletManager.pool.Get();

            shootTimer = shootCooldown;
            bulletsInMag--;
        }
    }

    
    public void Reload()
    {
        bulletsInMag = magSize;
    }

    public void ToggleAim()
    {
        //animator.SetBool("ADSing", !animator.GetBool("ADSing"));
    }

}
