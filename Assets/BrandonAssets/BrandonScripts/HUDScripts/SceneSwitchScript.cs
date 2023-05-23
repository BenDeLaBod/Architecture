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
    void Start()
    {
        _ddolObjects = GameObject.FindObjectsOfType<DontDestroy>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
        CheckScene();
    }

    public void SwitchStandOff()
    {
        SceneManager.LoadScene(1);
    }
    public void SwitchMainScene()
    {
        SceneManager.LoadScene(0);
    }

    public void CheckScene()
    {
        _currerntScene = SceneManager.GetActiveScene();
        _currenSceneIndex = _currerntScene.buildIndex;
        if (_currerntScene.buildIndex == 1)
        {
            foreach (DontDestroy ddol in _ddolObjects)
            {
                if(ddol.gameObject.CompareTag("SceneManager") != true)
                {
                    ddol.gameObject.SetActive(false);
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
}
