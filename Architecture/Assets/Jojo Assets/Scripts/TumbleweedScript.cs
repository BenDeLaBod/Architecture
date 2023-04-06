using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float radius;
    public int movementSpeed;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale *= radius * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(-movementSpeed, 0.0f, 0.0f);

        rigidBody.AddForce(movement * movementSpeed);
    }
}
