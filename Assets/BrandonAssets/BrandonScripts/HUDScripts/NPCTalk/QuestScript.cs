using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [SerializeField] private NPCManager _npcManager;
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private string currentNPCTalking;

    private void Update()
    {
        currentNPCTalking = GameObject.Find("TalkController").GetComponent<TalkController>().npcDisplayName.text;
    }

    public void SayQuest()
    {
        questText.text = _npcManager.GenerateQuestText(currentNPCTalking);
    }
}
