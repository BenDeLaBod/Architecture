using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DuelScript : MonoBehaviour
{
    [SerializeField] Animator playerAnimator, enemyAnimator;
    bool success, hasShot;

    [SerializeField] private GameObject gunObject, enemyGunObject;

    private Gun gun;

    // Start is called before the first frame update
    void Start()
    {
        gun = gunObject.GetComponent<Gun>();
        gunObject.SetActive(false);
        enemyGunObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasShot)
        {
            Transition(false);
        }

        if (!hasShot && Input.GetKeyDown(KeyCode.Mouse0))
        {
            DuelUIScript.instance.StopPin();
            success = DuelUIScript.instance.HitOrMiss();
            hasShot = true;
            gunObject.SetActive(true);
            enemyGunObject.SetActive(true);
            Transition(true);
            

            playerAnimator.SetBool("Died", !success);
            enemyAnimator.SetBool("Died", success);

            
        }
    }

    void Transition(bool input)
    {
        playerAnimator.SetBool("HasFired", input);
        enemyAnimator.SetBool("HasFired", input);
    }

    public void DeactivateGun()
    {
        if (success)
        {
            gunObject.SetActive(false);
        }
        else
        {
            enemyGunObject.SetActive(false);
        }
    }


}
