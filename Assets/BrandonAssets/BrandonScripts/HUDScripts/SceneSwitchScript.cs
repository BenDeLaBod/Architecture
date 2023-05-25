using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitchScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] DontDestroy[] _ddolObjects;

    private Scene _currerntScene;
    [SerializeField] int _currenSceneIndex;
    private NPCManager _npcManager;
    public static bool duelWon;



    List<DontDestroy> _ddolObjectList ;
   
    void Start()
    {

        _ddolObjects = GameObject.FindObjectsOfType<DontDestroy>();
        _npcManager = GameObject.Find("NPC Manager").GetComponent<NPCManager>();
        _ddolObjectList = new List<DontDestroy>(_ddolObjects);
    }

    // Update is called once per frame
    void Update()
    {

        _ddolObjectList.RemoveAll(x => x == null);
        _ddolObjects = _ddolObjectList.ToArray();
        CheckScene();
    }

    public void SwitchStandOff()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchMainScene()
    {
        SceneManager.LoadScene(0);
        _npcManager.DuelWon(duelWon);
        UpdateDDOLArray();
    }

    public void CheckScene()
    {
        _currerntScene = SceneManager.GetActiveScene();
        _currenSceneIndex = _currerntScene.buildIndex;
        if (_currerntScene.buildIndex == 1)
        {
            foreach (DontDestroy ddol in _ddolObjects)
            {
                ddol.gameObject.SetActive(false);
                if (ddol.gameObject.CompareTag("SceneManager"))
                {
                    ddol.gameObject.SetActive(true);
                }
                else if (ddol.gameObject.CompareTag("NPCManager"))
                {
                    ddol.gameObject.SetActive(true);
                }

            }
        }
        if(_currerntScene.buildIndex == 0)
        {
            foreach (DontDestroy ddol in _ddolObjects)
            {
                ddol.gameObject.SetActive(true);
            }


        }
    }

    public void UpdateDDOLArray()
    {
        _ddolObjects = GameObject.FindObjectsOfType<DontDestroy>();
        
    }
}
