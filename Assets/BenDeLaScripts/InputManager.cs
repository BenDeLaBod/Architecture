using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode reload, shoot, aim;
    [SerializeField] private KeyCode hats;

    [SerializeField] private GameObject gunObject;
    

    private Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = gunObject.GetComponent<Gun>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(shoot) && gun.isAming)
        {
            gun.Shoot();
            
        }

        if (Input.GetKeyDown(reload))
        {
            gun.Reload();
            
        }

        if (Input.GetKey(aim))
        {
            gun.ToggleAim();
        }
    }
}
