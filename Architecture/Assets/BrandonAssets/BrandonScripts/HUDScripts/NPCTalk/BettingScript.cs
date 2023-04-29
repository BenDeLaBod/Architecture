using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BettingScript : MonoBehaviour
{


    [SerializeField] private TextMeshProUGUI _bettingText;
    [SerializeField] private int _bettingMoney;
    public void Add5()
    {
        _bettingMoney +=5;
        UpdateBettingText();
    }
    public void Add10()
    {
        _bettingMoney += 10;
        UpdateBettingText();
    }
    public void Add20()
    {
        _bettingMoney += 20;
        UpdateBettingText();
    }
    public void Add50()
    {
        _bettingMoney += 50;
        UpdateBettingText();
    }
    public void Add100()
    {
        _bettingMoney += 100;
        UpdateBettingText();
    }

    private void UpdateBettingText()
    {
        _bettingText.text =  "Your bet amount: $" +  _bettingMoney.ToString();
    }


}
