using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    public GameObject[] _sceneManager;
    public GameObject[] _player;
    private void Awake()
    {
        _sceneManager = GameObject.FindGameObjectsWithTag("SceneManager");
        _player = GameObject.FindGameObjectsWithTag("Player");

        if (_sceneManager.Length > 1)
        {
            Destroy(this.gameObject);
        }
        if(_player.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
