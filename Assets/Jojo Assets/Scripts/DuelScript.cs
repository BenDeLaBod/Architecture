using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuelScript : MonoBehaviour
{
    [SerializeField] Animator animator;
    bool success, hasShot;
    // Start is called before the first frame update
    void Start()
    {
        
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
            hasShot = true;
            Transition(true);
            DuelUIScript.instance.StoppPin();
            success = DuelUIScript.instance.HitOrMiss();

            Debug.Log(success);
        }
    }

    void Transition(bool input)
    {
        animator.SetBool("HasFired", input);
    }
}
