using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalkHUDManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Canvas _NPCchoiceCanvas;
    [SerializeField] private RectTransform _playerHealth;
    [SerializeField] private RectTransform _playerGold;
    [SerializeField] private RectTransform _playerWeapon;
    Vector2 _healthPos;
    Vector2 _goldPos;
    Vector2 _weaponPos;


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
    public void ShowNPCHUD()
    {
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
        
    }
}
