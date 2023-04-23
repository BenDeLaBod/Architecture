using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCInteract : MonoBehaviour, Interactable
{

    [SerializeField] private string _promt;
    [SerializeField] private Canvas _NPCchoiceCanvas;  
    [SerializeField] private RectTransform _playerHealth;
    [SerializeField] private RectTransform _playerGold;
    [SerializeField] private RectTransform _playerWeapon;

    public string InteractionPromt => _promt;

    public bool Hover(Interactor interactor)
    {
        return true;
    }

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Talk to NPC");

        _playerHealth.anchoredPosition = new Vector2(_playerHealth.anchoredPosition.x +120, _playerHealth.anchoredPosition.y + 331);
        _playerGold.anchoredPosition = new Vector2(_playerGold.anchoredPosition.x +120, _playerGold.anchoredPosition.y + 325);
        _playerWeapon.anchoredPosition = new Vector2(_playerWeapon.anchoredPosition.x, _playerWeapon.anchoredPosition.y + 320);
        _NPCchoiceCanvas.gameObject.SetActive(true);

        return true;
    }
}
