using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    // public GameObject barrelPosition;

    bool pressing;

    float gunTimer;
    [SerializeField] private float gunCooldown;

    [SerializeField] private int magSize;
    private int bulletsInMag;

    [SerializeField] private GameObject bulletSpawnPoint;

    void Start()
    {
        gunTimer = gunCooldown;
        bulletsInMag = magSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (gunTimer <= 0)
        {
            if (bulletsInMag > 0 && Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (!pressing)
                {
                    Shoot(transform);
                    bulletsInMag--;
                }
                pressing = true;

                gunTimer = gunCooldown;
            }
            else
            {
                pressing = false;
            }
        }
        else
        {
            gunTimer -= Time.deltaTime;
        }

        if (bulletsInMag == 0)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                Reload();
            }
        }
    }

    /// <summary>
    /// Spawn a bullet prefab 
    /// </summary>
    /// <param name="shootPos"> The position where the bullet spawns from</param>
    public void Shoot(Transform shootPos)
    {
        Instantiate(projectilePrefab, /*transform.position +*/ bulletSpawnPoint.transform.position, shootPos.transform.rotation);
    }

    
    public void Reload()
    {
        bulletsInMag = magSize;
    }
}
