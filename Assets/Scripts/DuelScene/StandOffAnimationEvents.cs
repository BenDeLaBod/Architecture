using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandOffAnimationEvents : MonoBehaviour
{
    [SerializeField] GameObject duelObject;
    private DuelScript duelScript;
    // Start is called before the first frame update
    void Start()
    {
        duelScript = duelObject.GetComponent<DuelScript>();
    }


    public void DeactivateGun()
    {
        duelScript.DeactivateGun();
    }
}
