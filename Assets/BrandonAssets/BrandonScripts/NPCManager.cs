using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    
    [SerializeField] private NPCInfo[] _npcArray;
    float x;
    float y;
    float z;
    public GameObject newNpc;
    [SerializeField] private Sprite[] _npcSprites;
 


    //Generate Names
    public string loadNameListPath;
    [SerializeField] private List<string> _npcNames = new List<string>();



    //Generate Quest
    public string loadQuestionPath;
    public string loadRewardPath;
    [SerializeField] private List<string> _questionList = new List<string>();
    [SerializeField] private List<string> _rewardList = new List<string>();



    void Start()
    {
        _npcArray = FindObjectsOfType<NPCInfo>();
        var stream = new StreamReader(loadNameListPath);
        while (!stream.EndOfStream)
        {
            _npcNames.Add(stream.ReadLine());
        }


        var streamQuestion = new StreamReader(loadQuestionPath);
        var streamReward = new StreamReader(loadRewardPath);
        while (!streamQuestion.EndOfStream)
        {
            _questionList.Add(streamQuestion.ReadLine());
        }
        while (!streamReward.EndOfStream)
        {
            _rewardList.Add(streamReward.ReadLine());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnNewNPC();
        }
    }

    private void SpawnNewNPC()
    {
        x = Random.Range(0, 10);
        y = 6;
        z = 10;
        Vector3 randomPos = new Vector3(x, y, z);
        newNpc.transform.position = randomPos;
        Instantiate(newNpc, newNpc.transform.position,newNpc.transform.rotation);
        
        //New NPC Info
        var newNPCInfo = newNpc.GetComponent<NPCInfo>();
        newNPCInfo._name = _npcNames[Random.Range(0, _npcNames.Count)];
        newNpc.name = newNPCInfo._name;

        newNPCInfo._cowboySprite = _npcSprites[Random.Range(0, _npcSprites.Length)];



        _npcArray = FindObjectsOfType<NPCInfo>();
    }

    public string GenerateQuestText(string NPCTalking)
    {
        string wantedNPC = "***";
        string questionText = _questionList[Random.Range(0, _questionList.Count)];
        if (questionText.Contains(wantedNPC))
        {
            StringBuilder sb = new StringBuilder(questionText);
            //questionText.IndexOf(wantedNPC);
            sb.Remove(questionText.IndexOf(wantedNPC), wantedNPC.Length);
            sb.Insert(questionText.IndexOf(wantedNPC), _npcNames[Random.Range(0, _npcNames.Count)]);


            //questionText.Replace(wantedNPC, _npcNames[Random.Range(0, _npcNames.Count)]);
            questionText = sb.ToString(); ;
            
            Debug.LogWarning("Replace: " + questionText);
        }



        string questPromt = /*_questionList[Random.Range(0, _questionList.Count)]*/ questionText + " " + _rewardList[Random.Range(0, _rewardList.Count)] /*+ NPCTalking*/;
        Debug.LogWarning(questionText+ " "+ _rewardList[Random.Range(0, _rewardList.Count)] + NPCTalking);

        return questPromt;
    }
}
