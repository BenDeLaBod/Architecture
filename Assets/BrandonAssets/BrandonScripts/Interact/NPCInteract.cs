using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;
    [SerializeField] private NPCTalkHUDManager _talkManager;
    [SerializeField] private TalkController _talkController;
    [SerializeField] private NPCManager _npcManager;
    [SerializeField] private NPCInfo _npcInfo;


    private void Start()
    {
        _talkManager = GameObject.Find("NPCHUDManager").GetComponent<NPCTalkHUDManager>();
        _talkController = GameObject.Find("TalkController").GetComponent<TalkController>();
        _npcManager = GameObject.Find("NPC Manager").GetComponent<NPCManager>();
    }

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");

        _talkController.ToggleCanvas(true);

        if (!_talkManager.showHUD)
        {
            _npcInfo.UpdateNPCInfo();
            _talkManager.ShowNPCHUD();
        }

        _npcManager.SetInteractingNPC(gameObject);
        return true;
    }
}
