using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    
    [SerializeField] public NPCInfo[] npcArray;
    public GameObject newNpc;
    [SerializeField] private Sprite[] _npcSprites;
    [SerializeField] private Transform[] _patrolPoints; 


    //Generate Names
    public string loadNameListPath;
    [SerializeField] public List<string> npcNames = new List<string>();
    private List<string> _usedNPCNames = new List<string>();
    string giveRandomName;

   [SerializeField] GameObject _wantedNPC;

    private static bool m_Initialized = false;

   
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);



        if (!m_Initialized)
        {
            m_Initialized = true;
            // this is only run once
            LoadNames();
            int npcCount = npcNames.Count;




            for (int i = 0; i < npcCount; i++)
            {
                giveRandomName = npcNames[Random.Range(0, npcNames.Count)];

                while (_usedNPCNames.Contains(giveRandomName))
                {
                    giveRandomName = npcNames[Random.Range(0, npcNames.Count)];
                }
                _usedNPCNames.Add(giveRandomName);


                for (int j = 0; j < 5; j++)
                {
                    newNpc.gameObject.GetComponent<PatrolPoints>().AddPatrolPoint(_patrolPoints[Random.Range(0, _patrolPoints.Length)], i);
                }


                SpawnNewNPC(giveRandomName);
            }

        }


        //npcArray = FindObjectsOfType<NPCInfo>();

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
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    SpawnNewNPC();
        //} 
    }

    private void SpawnNewNPC(string giveName)
    {

        //Assign NPC Info
        newNpc.GetComponent<NPCInfo>()._name = giveName;
        newNpc.name = giveName;

        newNpc.GetComponent<NPCInfo>()._cowboySprite = _npcSprites[Random.Range(0, _npcSprites.Length)];

       


        //Spawn NPC
        Instantiate(newNpc, _patrolPoints[Random.Range(0, _patrolPoints.Length)].position, newNpc.transform.rotation);
       
        npcArray = FindObjectsOfType<NPCInfo>();
        
    }

    public Transform RandomTransform()
    {
        return _patrolPoints[Random.Range(0, _patrolPoints.Length)];
    }

    public void WantedNPC(string wantedNPCName)
    {
        foreach (NPCInfo npcWanted in npcArray)
        {
            npcWanted.GetComponent<HighlightInteract>().ToggleWanted(false);
            if ( npcWanted._name == wantedNPCName )
            {
                _wantedNPC = npcWanted.gameObject;
                _wantedNPC.GetComponent<HighlightInteract>().ToggleWanted(true);
            }

        }     
    }
   
}
