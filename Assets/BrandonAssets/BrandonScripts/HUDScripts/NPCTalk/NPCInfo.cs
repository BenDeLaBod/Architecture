using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite _cowboySprite;
    [SerializeField] private Image _cowboyImage;

    [SerializeField] public string _name;
    TalkController _talkController;
    private void Start()
    {
         _talkController = GameObject.FindAnyObjectByType<TalkController>();
        UpdateNPCInfo();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void UpdateNPCInfo()
    {
        //_talkController.SetImage(_cowboySprite);
        _talkController.SetDisplayName(_name);
    }
}
