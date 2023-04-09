using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    Vector2 mousePos;
    public PlayerController playerControllerScript;
    void Start()
    {
        playerControllerScript = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

       // PlayerAim();
        HandleRotationInpt();
       
    }

    //private void PlayerAim()
    //{ 
    //    //Get Screen position of object/player
    //    Vector2 positionOnScreen = cam.WorldToViewportPoint(transform.position);

    //    //Get Screen position of the mouse 
    //    Vector2 mouseOnScreen = (Vector2)cam.ScreenToViewportPoint(Input.mousePosition);

    //    float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

    //    transform.rotation = Quaternion.Euler(new Vector3(0f, -1*angle -90, 0f));

    //}

    //float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    //{
    //    Vector3 direction = a-b;
    //    return Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
    //}

    void HandleRotationInpt()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }
}
