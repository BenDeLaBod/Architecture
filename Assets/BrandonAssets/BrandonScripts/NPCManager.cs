using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    
    [SerializeField] public NPCInfo[] npcArray;
    float x;
    float y;
    float z;
    public GameObject newNpc;
    [SerializeField] private Sprite[] _npcSprites;
 


    //Generate Names
    public string loadNameListPath;
    [SerializeField] public List<string> npcNames = new List<string>();
    List<string> assignedName = new List<string>();
    string giveRandomName;

   [SerializeField] GameObject _wantedNPC;

   
    void Start()
    {
        

        LoadNames();
        int npcCount = npcNames.Count;
        for (int i = 0; i < npcCount; i++)
        {
            SpawnNewNPC(npcNames[i]); 
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
        x = Random.Range(-10, 10);
        y = 6;
        z = Random.Range(0,10);
        Vector3 randomPos = new Vector3(x, y, z);
        newNpc.transform.position = randomPos;
        Instantiate(newNpc, newNpc.transform.position,newNpc.transform.rotation);
        
        //New NPC Info
        newNpc.GetComponent<NPCInfo>()._name = giveName;
        newNpc.name = giveName;

        newNpc.GetComponent<NPCInfo>()._cowboySprite = _npcSprites[Random.Range(0, _npcSprites.Length)];

        npcArray = FindObjectsOfType<NPCInfo>();
        
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
