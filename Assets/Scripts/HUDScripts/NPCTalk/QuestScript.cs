using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    [SerializeField] private TextMeshProUGUI questText;
    [SerializeField] private string currentNPCTalking;

    private void Update()
    {
        currentNPCTalking = GameObject.Find("TalkController").GetComponent<TalkController>().npcDisplayName.text;
    }

    public void SayQuest()
    {
        questText.text = _questManager.GenerateQuestText(currentNPCTalking);
    }
}
