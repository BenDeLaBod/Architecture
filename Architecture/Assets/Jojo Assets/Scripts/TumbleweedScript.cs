using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TumbleweedScript : MonoBehaviour
{
    public Rigidbody rigidBody;
    public float radius, movementSpeed;
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
        if (transform.position.x > -70)
        {
            Vector3 movement = new Vector3(-1.0f, 0.0f, 0.0f) * movementSpeed * Time.fixedDeltaTime;

            rigidBody.AddForce(movement * movementSpeed);
        }
        else
        {
            Destroy(rigidBody);
        }
    }
}
