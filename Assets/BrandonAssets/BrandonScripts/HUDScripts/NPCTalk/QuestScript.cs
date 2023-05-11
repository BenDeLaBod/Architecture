using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestScript : MonoBehaviour
{
    [SerializeField] private NPCManager _npcManager;
    [SerializeField] private TextMeshProUGUI questText;

    private void Start()
    {
       

    }

    public void SayQuest()
    {
        questText.text = _npcManager.GenerateQuestText("test name");
    }
}
