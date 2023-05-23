using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    
    [SerializeField] private NPCManager _npcManager;

    //Generate Names
    [SerializeField] private List<string> _npcNamesList = new List<string>();

    //Generate Quest
    public string loadQuestionPath;
    public string loadRewardPath;
    [SerializeField] private List<string> _questionList = new List<string>();
    [SerializeField] private List<string> _rewardList = new List<string>();

    [Header("Quest string placeholder")]
    string _placeholderWantedNPC = "***";
    string _placeholderReward = "---";
    string _replacePlayerName = "///";
    string _questionText;
    string _playerName;
    string _rewardText;
    string _randomWantedNpc;


    
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        _playerName = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfoScript>().playerName;

        _npcNamesList = _npcManager.npcNames;

        LoadQuestions();
        LoadReward();
    }

    private void Update()
    {

       
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

        _questionText = _questionList[Random.Range(0, _questionList.Count)];
        _rewardText = _rewardList[Random.Range(0, _rewardList.Count)];


        _randomWantedNpc = _npcNamesList[Random.Range(0, _npcNamesList.Count)];
        while (_randomWantedNpc == NPCTalking)  //Prevent NPC form requesting itself as a hit.
        {
            _randomWantedNpc = _npcNamesList[Random.Range(0, _npcNamesList.Count)];
        }

        _npcManager.WantedNPC(_randomWantedNpc);




        if (_questionText.Contains(_placeholderWantedNPC))
        {
            _questionText = SetWantedNPCName(_questionText, _randomWantedNpc);
        }
        if (_rewardText.Contains(_placeholderReward))
        {
            _rewardText = SetRewardAmount(_rewardText, Random.Range(100, 500));
        }
        if (_rewardText.Contains(_placeholderWantedNPC))
        {
            _rewardText = SetWantedNPCName(_rewardText, _randomWantedNpc);
        }
        if (_questionText.Contains(_replacePlayerName))
        {
            _questionText = SetPlayerName(_questionText, _playerName);
        }
        if (_rewardText.Contains(_replacePlayerName))
        {
            _rewardText = SetPlayerName(_rewardText, _playerName);
        }
        string questPromt = _questionText + " " + _rewardText;

        return questPromt;
    }

    private string SetWantedNPCName(string questText, string name)
    {
        StringBuilder sb = new StringBuilder(questText);

        sb.Remove(questText.IndexOf(_placeholderWantedNPC), _placeholderWantedNPC.Length);
        sb.Insert(questText.IndexOf(_placeholderWantedNPC), "<color=#d62d2d>" + name + "</color>");

        questText = sb.ToString();
        return questText;
    }

    private string SetRewardAmount(string _rewardText, int rewardAmount)
    {
        StringBuilder sbReward = new StringBuilder(_rewardText);

        sbReward.Remove(_rewardText.IndexOf(_placeholderReward), _placeholderReward.Length);
        sbReward.Insert(_rewardText.IndexOf(_placeholderReward), "<color=#FFD700>" + rewardAmount + "</color>");

        _rewardText = sbReward.ToString();

        return _rewardText;
    }

    private string SetPlayerName(string _rewardText, string name)
    {
        StringBuilder sb = new StringBuilder(_rewardText);

        sb.Remove(_rewardText.IndexOf(_replacePlayerName), _replacePlayerName.Length);
        sb.Insert(_rewardText.IndexOf(_replacePlayerName), "<color=#52c5fa>" + name + "</color>");

        _rewardText = sb.ToString();
        return _rewardText;
    }
}
