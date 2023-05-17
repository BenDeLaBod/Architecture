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
    [SerializeField] public List<string> npcNames = new List<string>();



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

    void Start()
    {
        _npcArray = FindObjectsOfType<NPCInfo>();

        LoadNames();
       
        _playerName = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfoScript>().playerName;
    }

    private void LoadNames()
    {
        var stream = new StreamReader(loadNameListPath);
        while (!stream.EndOfStream)
        {
            npcNames.Add(stream.ReadLine());
        }
    }

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
        newNPCInfo._name = npcNames[Random.Range(0, npcNames.Count)];
        newNpc.name = newNPCInfo._name;

        newNPCInfo._cowboySprite = _npcSprites[Random.Range(0, _npcSprites.Length)];

        _npcArray = FindObjectsOfType<NPCInfo>();
    }
   
}
