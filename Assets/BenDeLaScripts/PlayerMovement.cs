using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float mouseX;
    float mouseY;
    float fwdbwd;
    float lftrgt;

    [SerializeField]
    private float sensitivity;
    [SerializeField]
    private float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        fwdbwd = Input.GetAxis("Vertical") * movementSpeed;
        lftrgt = Input.GetAxis("Horizontal") * movementSpeed;
    }

    private void FixedUpdate()
    {
        //transform.Rotate(mouseY, mouseX, mouseY);
        transform.Translate(lftrgt, 0, fwdbwd);
    }
}
