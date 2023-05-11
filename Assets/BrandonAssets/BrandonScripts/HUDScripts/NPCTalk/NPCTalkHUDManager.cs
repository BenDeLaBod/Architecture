using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCTalkHUDManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Canvas _NPCchoiceCanvas;
    [SerializeField] private RectTransform _playerHealth;
    [SerializeField] private RectTransform _playerGold;
    [SerializeField] private RectTransform _playerWeapon;
    [SerializeField] private PlayerMove _playerMoveScript;
    [SerializeField] private CinemachineFreeLook _thirdPersonCamera;
    Vector2 _healthPos;
    Vector2 _goldPos;
    Vector2 _weaponPos;

    [Header("Duel")]
    [SerializeField] private GameObject _duelQuest;
    [SerializeField] private GameObject _duelSelected;

    [Header("Quest")]
    [SerializeField] private GameObject _questSelected;
    public bool showHUD;
    void Start()
    {
        _healthPos = _playerHealth.anchoredPosition;
        _goldPos = _playerGold.anchoredPosition;
        _weaponPos = _playerWeapon.anchoredPosition;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (showHUD && Input.GetKeyDown(KeyCode.Q))
        {
            HideNPCHUD();
        }
    }
    /// <summary>
    /// Shows the NPC talk HUD. And moves Health, Gold and Weapon HUD element to new positions 
    /// </summary>
    public void ShowNPCHUD()
    {
        _playerMoveScript.enabled = false;
        _thirdPersonCamera.m_YAxis.m_MaxSpeed = 2;
        _thirdPersonCamera.m_XAxis.m_MaxSpeed = 30;
        showHUD = true;
        _playerHealth.anchorMin = new Vector2(0, 1);
        _playerHealth.anchorMax = new Vector2(0, 1);
        _playerGold.anchorMin = new Vector2(0, 1);
        _playerGold.anchorMax = new Vector2(0, 1);
        _playerWeapon.anchorMin = new Vector2(1, 1);
        _playerWeapon.anchorMax = new Vector2(1, 1);
        _playerHealth.anchoredPosition = new Vector2(_playerHealth.anchoredPosition.x + 117, _playerHealth.anchoredPosition.y - 126); ;
        _playerGold.anchoredPosition = new Vector2(_playerGold.anchoredPosition.x + 120, _playerGold.anchoredPosition.y - 140);
        _playerWeapon.anchoredPosition = new Vector2(_playerWeapon.anchoredPosition.x, _playerWeapon.anchoredPosition.y - 126);
        _NPCchoiceCanvas.gameObject.SetActive(true);
    }
    /// <summary>
    /// Resets Health, Gold and Weapon HUD elements to its original settings. And hides the NPC talk HUD
    /// </summary>
    public void HideNPCHUD()
    {
        _playerHealth.anchorMin = new Vector2(0, 0);
        _playerHealth.anchorMax = new Vector2(0, 0);
        _playerGold.anchorMin = new Vector2(0, 0);
        _playerGold.anchorMax = new Vector2(0, 0);
        _playerWeapon.anchorMin = new Vector2(1, 0);
        _playerWeapon.anchorMax = new Vector2(1, 0);
        _playerHealth.anchoredPosition = _healthPos;
        _playerGold.anchoredPosition = _goldPos;
        _playerWeapon.anchoredPosition = _weaponPos;
        _NPCchoiceCanvas.gameObject.SetActive(false);
        showHUD = false;
        _playerMoveScript.enabled = true;
        //_thirdPersonCamera.enabled = true;
    }

    public void DuelSelected()
    {
        _duelSelected.SetActive(true);
        _duelQuest.SetActive(false);
    }

    public void QuestSelected()
    {

    }

}
