using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private GameObject[] _sceneManager;
    private GameObject[] _player;
   // private GameObject[] _cavas;
    private void Awake()
    {
        _sceneManager = GameObject.FindGameObjectsWithTag("SceneManager");
        _player = GameObject.FindGameObjectsWithTag("Player");
        _player = GameObject.FindGameObjectsWithTag("MainCamera");

        if (_sceneManager.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if(_player.Length > 1)
        {
            Destroy(this.gameObject);
        }
        //if (_cavas.Length > 1)
        //{
        //    Destroy(this.gameObject);
        //}

        DontDestroyOnLoad(this.gameObject);
    }
}
