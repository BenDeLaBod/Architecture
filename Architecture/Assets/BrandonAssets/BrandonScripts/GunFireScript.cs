using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject projectilePrefab;
    public GameObject barrelPosition;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, barrelPosition.transform.position, barrelPosition.transform.rotation);
        }
    }

    
}
