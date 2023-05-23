using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed, runningMovementSpeed, smoothRotationTime;
    private float turnSmoothVelocity, gravityConstant;
    private Vector3 direction;
    bool sprint;

    public CharacterController controller;
    public Transform cameraTransform;
    public Animator animator;

    [SerializeField] CinemachineVirtualCamera vCam;
    [SerializeField] CinemachineFreeLook fCam;
    [SerializeField] Image crosshair;

    // Start
    private void Start()
    {
        crosshair.enabled = false;
        gravityConstant = 9.82f;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        sprint = Input.GetKey(KeyCode.LeftControl);
        direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            animator.SetBool("ADSing", !animator.GetBool("ADSing"));
            ChangeCamera();
            crosshair.enabled = !crosshair.isActiveAndEnabled;
        }
    }

    private void FixedUpdate()
    {
        if (direction != Vector3.zero)
        {
            animator.SetBool("isMoving", true);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothRotationTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDirection = (Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward).normalized;
            moveDirection.y = -gravityConstant;

            if (sprint)
            {
                animator.SetBool("isSprinting", true);
                controller.Move(moveDirection * runningMovementSpeed * Time.fixedDeltaTime);
            }
            else
            {
                animator.SetBool("isSprinting", false);
                controller.Move(moveDirection * movementSpeed * Time.fixedDeltaTime);
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void ChangeCamera()
    {
        if (vCam.isActiveAndEnabled)
        {
            vCam.enabled = false;
            fCam.enabled = true;
        }
        else
        {
            fCam.enabled = false;
            vCam.enabled = true;
        }
    }
}
