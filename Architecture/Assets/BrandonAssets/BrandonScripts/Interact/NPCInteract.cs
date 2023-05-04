using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;
    [SerializeField] private NPCTalkHUDManager _talkManager;

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");

        if (!_talkManager.showHUD)
        {
            _talkManager.ShowNPCHUD();
        }
        return true;
    }
}
