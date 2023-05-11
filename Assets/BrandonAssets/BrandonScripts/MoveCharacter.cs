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
    public PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

        
        Vector3 direction =  playerControllerScript.GetDirection().normalized;

        controller.Move(moveSpeed * Time.deltaTime * direction);
        

        if (direction != Vector3.zero)
        {
            gameObject.transform.forward = direction;
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity*Time.deltaTime);

        
    }


}
