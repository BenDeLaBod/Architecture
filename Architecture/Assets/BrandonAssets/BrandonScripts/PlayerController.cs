using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(HealthPoints))]
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    protected Vector3 direction;
    public Vector3 GetDirection()
    {
        return direction;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }
}
