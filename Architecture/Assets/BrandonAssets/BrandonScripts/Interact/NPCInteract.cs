using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");
        return true;
    }
}
