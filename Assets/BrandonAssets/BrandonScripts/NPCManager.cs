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
    [Header("Generate Name")]
    public string loadNameListPath;
    [SerializeField] public List<string> npcNames = new List<string>();
    private List<string> _usedNPCNames = new List<string>();
    string giveRandomName;

    [Header("Generate NPC body")]
    [SerializeField] GameObject[] _mainBody;
    [SerializeField] GameObject[] _hatOptions;

    [Header("NPC Quest")]
    [SerializeField] GameObject _wantedNPC;
    [SerializeField] int _reawardAmount;
    [SerializeField] GameObject _interactingNPC;

    private static bool m_Initialized = false;

    [SerializeField] SceneSwitchScript _sceneManager;

    [SerializeField] double _bettingAmount;


    void Start()
    {
        _sceneManager = GameObject.Find("Scene Manager").GetComponent<SceneSwitchScript>();
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

        //InteractionNPCFate(duelWon);
        npcArray = FindObjectsOfType<NPCInfo>();
    }

    private void SpawnNewNPC(string giveName)
    {

        //Assign NPC Info
        newNpc.GetComponent<NPCInfo>()._name = giveName;
        newNpc.name = giveName;
        newNpc.GetComponent<NPCInfo>()._cowboySprite = _npcSprites[Random.Range(0, _npcSprites.Length)];
        newNpc.gameObject.GetComponent<HealthPoints>().deathMoney = Random.Range(100, 300);

        //Spawn NPC
        var npc = Instantiate(newNpc, _patrolPoints[Random.Range(0, _patrolPoints.Length)].position, newNpc.transform.rotation);
        var npcBody = Instantiate(GetRandomMainBody(), new Vector3(npc.transform.position.x, npc.transform.position.y -1.5f,
            npc.transform.position.z), npc.transform.rotation, npc.transform);


        var npcBodyComponent = npcBody.GetComponent<GetBodyRenderer>();
        Instantiate(GetRandomHat(), npcBodyComponent.hatPlacement.transform);

        npc.GetComponent<HealthPoints>().GetAnimator(npcBody.GetComponent<Animator>());
        npc.GetComponent<StateMachine>().GetAnimator(npcBody.GetComponent<Animator>());
        npc.GetComponent<HighlightInteract>().GetRenderer(npcBodyComponent.renderers);

        //npcArray = FindObjectsOfType<NPCInfo>();

    }

    public Transform RandomTransform()
    {
        return _patrolPoints[Random.Range(0, _patrolPoints.Length)];
    }

    public void WantedNPC(string wantedNPCName, int rewardAmount)
    {
        foreach (NPCInfo npcWanted in npcArray)
        {
            npcWanted.GetComponent<HighlightInteract>().ToggleWanted(false);
            if ( npcWanted._name == wantedNPCName )
            {
                _wantedNPC = npcWanted.gameObject;
                npcWanted.gameObject.GetComponent<HealthPoints>().deathMoney = rewardAmount + (int)_bettingAmount;
              
                _wantedNPC.GetComponent<HighlightInteract>().ToggleWanted(true);
            }

        }     
    }

    public void SetInteractingNPC(GameObject interactingNPC)
    {
        _interactingNPC = interactingNPC;
    }

    public void DuelWon(bool duelWon)
    {
        if (duelWon)
        {
            _interactingNPC.GetComponent<HealthPoints>().Die();
            //npcArray = FindObjectsOfType<NPCInfo>();
            //_sceneManager.UpdateDDOLArray();
        }
        
    }

    public void AddBettingMoney(double betting)
    {
        _bettingAmount = betting;
    }
   
    public GameObject GetRandomMainBody()
    {
        return _mainBody[Random.Range(0, _mainBody.Length)];
    }

    public GameObject GetRandomHat()
    {
        return _hatOptions[Random.Range(0, _hatOptions.Length)];
    }
}
