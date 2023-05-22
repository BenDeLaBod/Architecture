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

    [SerializeField] private GameObject bulletSpawnPoint;

    [SerializeField] private int magSize;
    private int bulletsInMag;


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
            Instantiate(projectilePrefab, bulletSpawnPoint.transform.position, transform.rotation);
            shootTimer = shootCooldown;
            bulletsInMag--;
        }
    }

    
    public void Reload()
    {
        bulletsInMag = magSize;
    }

}
