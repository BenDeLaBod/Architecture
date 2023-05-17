using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class QuestManager : MonoBehaviour
{

    //Generate Names
    public string loadNameListPath;
    [SerializeField] private List<string> _npcNames = new List<string>();

    

    //Generate Quest
    public string loadQuestionPath;
    public string loadRewardPath;
    [SerializeField] private List<string> _questionList = new List<string>();
    [SerializeField] private List<string> _rewardList = new List<string>();

    [Header("Quest string placeholder")]
    string placeholderWantedNPC = "***";
    string placeholderReward = "---";
    string replacePlayerName = "///";

    string _playerName;


    private void Start()
    {
        _playerName = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfoScript>().playerName;
        _npcNames = GameObject.Find("NPC Manager").GetComponent<NPCManager>().npcNames;

        LoadQuestions();
        LoadReward();
    }

    private void LoadQuestions()
    {
        var streamQuestion = new StreamReader(loadQuestionPath);
        while (!streamQuestion.EndOfStream)
        {
            _questionList.Add(streamQuestion.ReadLine());
        }
    }

    private void LoadReward()
    {
        var streamReward = new StreamReader(loadRewardPath);

        while (!streamReward.EndOfStream)
        {
            _rewardList.Add(streamReward.ReadLine());
        }
    }


    public string GenerateQuestText(string NPCTalking)
    {

        string questionText = _questionList[Random.Range(0, _questionList.Count)];
        //Prevent NPC form requesting itself as a hit.
        while (questionText == NPCTalking)
        {
            questionText = _questionList[Random.Range(0, _questionList.Count)];
        }

        string rewardText = _rewardList[Random.Range(0, _rewardList.Count)];
        string randomWantedName = _npcNames[Random.Range(0, _npcNames.Count)];

        if (questionText.Contains(placeholderWantedNPC))
        {
            questionText = SetWantedNPCName(questionText, randomWantedName);
        }
        if (rewardText.Contains(placeholderReward))
        {
            rewardText = SetRewardAmount(rewardText, Random.Range(100, 500));
        }
        if (rewardText.Contains(placeholderWantedNPC))
        {
            rewardText = SetWantedNPCName(rewardText, randomWantedName);
        }
        if (questionText.Contains(replacePlayerName))
        {
            questionText = SetPlayerName(questionText, _playerName);
        }
        if (rewardText.Contains(replacePlayerName))
        {
            rewardText = SetPlayerName(rewardText, _playerName);
        }
        string questPromt = questionText + " " + rewardText /*+ NPCTalking*/;

        return questPromt;
    }

    private string SetWantedNPCName(string questText, string name)
    {
        StringBuilder sb = new StringBuilder(questText);

        sb.Remove(questText.IndexOf(placeholderWantedNPC), placeholderWantedNPC.Length);
        sb.Insert(questText.IndexOf(placeholderWantedNPC), "<color=#d62d2d>" + name + "</color>");

        questText = sb.ToString();
        return questText;
    }

    private string SetRewardAmount(string _rewardText, int rewardAmount)
    {
        StringBuilder sbReward = new StringBuilder(_rewardText);

        sbReward.Remove(_rewardText.IndexOf(placeholderReward), placeholderReward.Length);
        sbReward.Insert(_rewardText.IndexOf(placeholderReward), "<color=#FFD700>" + rewardAmount + "</color>");

        _rewardText = sbReward.ToString();

        return _rewardText;
    }

    private string SetPlayerName(string _rewardText, string name)
    {
        StringBuilder sb = new StringBuilder(_rewardText);

        sb.Remove(_rewardText.IndexOf(replacePlayerName), replacePlayerName.Length);
        sb.Insert(_rewardText.IndexOf(replacePlayerName), "<color=#52c5fa>" + name + "</color>");

        _rewardText = sb.ToString();
        return _rewardText;
    }
}
