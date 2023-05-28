using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offsetVector;
    void Start()
    {
        transform.Translate(playerTransform.position + offsetVector);
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 cameraPosition = transform.position - (playerTransform.position + offsetVector);
        //transform.Translate(cameraPosition);
    }
}
