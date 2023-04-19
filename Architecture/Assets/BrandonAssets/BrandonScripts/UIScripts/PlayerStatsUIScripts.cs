using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUIScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerMoney;
    public int playerHealth;
    [SerializeField] private HealthPoints hp;
    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI healthText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = hp.healthPoints.ToString();
    }

    public void AddMoney(int moneyToAdd)
    {
        playerMoney += moneyToAdd;
        moneyText.text = "Gold: $" + playerMoney.ToString();
    }

    public void HealPlayerHP( int newHealth)
    {
        playerHealth += newHealth;
        healthText.text = playerHealth.ToString();

    }
}
