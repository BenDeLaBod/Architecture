using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPCInfo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Sprite _cowboyImage;
    [SerializeField] private Image _cowboyHeadshot;
    [SerializeField] private TextMeshProUGUI _displayName;
    [SerializeField] private string _name;
    private void Start()
    {
        
      
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void UpdateNPCInfo()
    {
        _cowboyHeadshot.sprite = _cowboyImage;
        _displayName.text = _name;
    }
}
