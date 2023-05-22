using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class AiShooting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    // public GameObject barrelPosition;
    public Transform Player { get; private set; }

    float gunTimer;
    [SerializeField] private float gunCooldown;

    [SerializeField] private int magSize;
    int bulletsInMag;

    private void Awake()
    {
        gunTimer = gunCooldown;
        bulletsInMag = magSize;
       // Player = GameObject.Find("Player1").transform;
        Player = GameObject.FindWithTag("Player").transform ;
    }
    public void shoot()
    {
        this.transform.LookAt(Player);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
     
        Debug.Log("shoot");
        if (gunTimer <= 0)
        {
            if (bulletsInMag > 0)
            {
                Debug.Log("shoot2");
                
                Shoot(transform);
                
                bulletsInMag--;

                gunTimer = gunCooldown;
            }
        }
        else
        {
            gunTimer -= Time.deltaTime;
        }

        if (bulletsInMag == 0)
        {
            Reload();
        }
    }
    /// <summary>
    /// Spawn a bullet prefab 
    /// </summary>
    /// <param name="shootPos"> The position where the bullet spawns from</param>
    public void Shoot(Transform shootPos)
    {
        Instantiate(projectilePrefab, shootPos.transform.position  + transform.forward, shootPos.transform.rotation);
    }


    public void Reload()
    {
        bulletsInMag = magSize;
    }
}