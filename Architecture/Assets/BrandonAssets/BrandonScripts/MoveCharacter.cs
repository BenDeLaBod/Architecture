using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed;
    public CharacterController controller;
    private Vector3 velocity;
    private float gravityValue = -9.82f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * moveSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        
    }
}
