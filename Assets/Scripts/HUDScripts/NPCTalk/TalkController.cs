using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGO;
    [SerializeField] private Image _npcImage;
    [SerializeField] private RawImage _npcProfile;
    [SerializeField] public TextMeshProUGUI npcDisplayName;
    public void ToggleCanvas(bool state)
    {
        _canvasGO.SetActive(state);    
    }

    public void EnableCanvas()
    {
        _canvasGO.SetActive(true);
    }

    public void SetImage(Sprite image)
    {
        _npcImage.sprite = image;
        
    }

 

    public void SetDisplayName(string name)
    {
        npcDisplayName.text = name;
    }
}
