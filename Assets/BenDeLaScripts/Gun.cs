using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update

    // public GameObject barrelPosition;

    float shootTimer;
    [SerializeField] private float shootCooldown;

    [SerializeField]
    private GameObject bulletSpawnPoint;

    [SerializeField] private int magSize;
    public int bulletsInMag;

    [SerializeField]
    private BulletManager bulletManager;
    public bool isAming;

    void Start()
    {
        Reload();
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
            GameObject bullet = bulletManager.GetBullet();

            bullet.transform.position = bulletSpawnPoint.transform.position;
            bullet.transform.rotation = transform.rotation;

            shootTimer = shootCooldown;
            bulletsInMag--;
        }
    }

    public float ShootColdownTime()
    {
        return shootTimer / shootCooldown;
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
