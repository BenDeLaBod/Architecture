using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;
    [SerializeField] private Canvas _NPCchoiceCanvas;  
    [SerializeField] private Canvas _playerHUDCanvas;
    [SerializeField] public RectTransform _playerHealth;

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");
        //_playerHUDCanvas.gameObject.SetActive(false);
       
        _playerHealth.anchoredPosition = new Vector2(  _playerHealth.anchoredPosition.x +50, _playerHealth.anchoredPosition.y + 200);
        _NPCchoiceCanvas.gameObject.SetActive(true);
        return true;
    }
}
