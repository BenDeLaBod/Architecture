using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NPCManager : MonoBehaviour
{

    
    [SerializeField] private NPCInfo[] _npcArray;
    float x;
    float y;
    float z;
    public GameObject newNpc;
 


    //Generate Names
    public string loadNameListPath;
    [SerializeField] private List<string> _npcNames = new List<string>();
    [SerializeField] private TextAsset _textDocList;
   

    
    void Start()
    {
        _npcArray = FindObjectsOfType<NPCInfo>();
        var stream = new StreamReader(loadNameListPath);
        while (!stream.EndOfStream)
        {
            _npcNames.Add(stream.ReadLine());
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
        x = Random.Range(-30, 30);
        y = Random.Range(0, 30);
        z = 6;
        Vector3 randomPos = new Vector3(x, y, z);
        newNpc.transform.position = randomPos;
        Instantiate(newNpc, newNpc.transform.position,newNpc.transform.rotation);
        
        //New NPC Info
        var newNPCInfo = newNpc.GetComponent<NPCInfo>();
        newNPCInfo._name = _npcNames[Random.Range(0, _npcNames.Count)];
        newNpc.name = newNPCInfo._name;
        newNPCInfo.UpdateNPCInfo();


        _npcArray = FindObjectsOfType<NPCInfo>();
    }
}
