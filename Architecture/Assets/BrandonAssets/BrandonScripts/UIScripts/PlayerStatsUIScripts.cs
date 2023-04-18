using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStatsUIScripts : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerMoney;
    [SerializeField] private TextMeshProUGUI moneyText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMoney(int moneyToAdd)
    {
        playerMoney += moneyToAdd;
        moneyText.text = "Gold: $" + playerMoney.ToString();
    }
}
