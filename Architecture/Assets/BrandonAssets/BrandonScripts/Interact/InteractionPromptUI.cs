using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{
    public Camera _mainCam;
    [SerializeField] private GameObject _uiPanel;
    [SerializeField] private TMPro.TMP_Text _promtText;

    public bool isDisplayed;

    private void Start()
    {
        _uiPanel.SetActive(false);
        ClosePanel();
    }

    private void LateUpdate()
    {
        var rotation = _mainCam.transform.rotation;
        transform.LookAt(transform.position + rotation * Vector3.forward,
                           rotation * Vector3.up);
    }

    
    public void SetUp(string promtText)
    {
        _promtText.text = promtText;
        _uiPanel.SetActive(true);
        isDisplayed = true;
    }

    public void ClosePanel() 
    {
        _uiPanel.SetActive(false);
        isDisplayed = false;
    }
}
