using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite _cowboyImage;
    [SerializeField] private Image _cowboyHeadshot;
    [SerializeField] private string _name;
    private void Start()
    {
        
        _cowboyHeadshot.sprite = _cowboyImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
