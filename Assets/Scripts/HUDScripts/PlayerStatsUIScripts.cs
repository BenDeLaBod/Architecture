using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUIScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerMoney;
    public int playerHealth;
    [SerializeField] private HealthPoints _hp;
    [SerializeField] private TextMeshProUGUI _moneyText;
    [SerializeField] private TextMeshProUGUI _healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _healthText.text = _hp.healthPoints.ToString();
    }

    public void AddMoney(int moneyToAdd)
    {
        playerMoney += moneyToAdd;
        _moneyText.text = "Gold: $" + playerMoney.ToString();
    }

    public void HealPlayerHP(int newHealth)
    {
        playerHealth += newHealth;
        _healthText.text = playerHealth.ToString();

    }
}
