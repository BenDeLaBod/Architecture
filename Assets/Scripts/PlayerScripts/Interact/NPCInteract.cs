using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;
    [SerializeField] private NPCTalkHUDManager _talkManager;
    [SerializeField] private TalkController _talkController;
    [SerializeField] private NPCManager _npcManager;
    [SerializeField] private NPCInfo _npcInfo;
    [SerializeField] private PatrolPoints _patrolPoints;
    [SerializeField] private NavMeshAgent _navAgent;

    private void Start()
    {
        _talkManager = GameObject.Find("NPCTalkHUDManager").GetComponent<NPCTalkHUDManager>();
        _talkController = GameObject.Find("TalkController").GetComponent<TalkController>();
        _npcManager = GameObject.Find("NPC Manager").GetComponent<NPCManager>();
        _patrolPoints = gameObject.GetComponent<PatrolPoints>();
        _navAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");

        Talking(true);
        _talkController.ToggleCanvas(true);

        if (!_talkManager.showHUD)
        {
            _npcInfo.UpdateNPCInfo();
            _talkManager.ShowNPCHUD();
        }

        _npcManager.SetInteractingNPC(gameObject);
        return true;
    }

    public void Talking(bool isTalking)
    {
        if (isTalking)
        {
            _navAgent.speed = 0f;
        }
        if(!isTalking)
        {
            _navAgent.speed = 3.5f;
        }
    }
}
