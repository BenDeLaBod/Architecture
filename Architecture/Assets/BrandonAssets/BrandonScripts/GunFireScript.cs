using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
   // public GameObject barrelPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    /// <summary>
    /// Spawn a bullet prefab 
    /// </summary>
    /// <param name="shootPos"> The position where the bullet spawns from</param>
    public void Shoot(Transform shootPos)
    {
        Instantiate(projectilePrefab, shootPos.transform.position, shootPos.transform.rotation);
    }

    
}
