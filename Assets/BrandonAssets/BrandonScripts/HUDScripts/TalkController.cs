using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TalkController : MonoBehaviour
{
    [SerializeField] private GameObject _canvasGO;
    [SerializeField] private Image _cowboyImage;
    [SerializeField] private TextMeshProUGUI _cowboyDisplayName;

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
        _cowboyImage.sprite = image;
    }

    public void SetDisplayName(string name)
    {
        _cowboyDisplayName.text = name;
    }


    


}
