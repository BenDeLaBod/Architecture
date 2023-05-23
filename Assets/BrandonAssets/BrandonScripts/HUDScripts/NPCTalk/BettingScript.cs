using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BettingScript : MonoBehaviour
{
    [SerializeField] private GoldManager _goldManager;
    [SerializeField] private TextMeshProUGUI _bettingText;
    [SerializeField] public double bettingMoney;
    Stack<int> _bettingHistory = new Stack<int>();
    [SerializeField] 

    public void Add5()
    {
        if (CheckEnoughGold(5))
        {
            bettingMoney += 5f;
            UpdateBettingText();
            _bettingHistory.Push(5);
        }
    }
    public void Add10()
    {
        if (CheckEnoughGold(10))
        {
            bettingMoney += 10f;
            UpdateBettingText();
            _bettingHistory.Push(10);
        }
       
    }
    public void Add20()
    {
        if (CheckEnoughGold(20))
        {
            bettingMoney += 20;
            UpdateBettingText();
            _bettingHistory.Push(20);
        }
    }
    public void Add50()
    {
        if (CheckEnoughGold(50))
        {
            bettingMoney += 50;
            UpdateBettingText();
            _bettingHistory.Push(50);
        }
    }
    public void Add100()
    {
        if (CheckEnoughGold(100))
        {
            bettingMoney += 100;
            UpdateBettingText();
            _bettingHistory.Push(100);
        }
    }

    public void UndoMoney()
    {
        if(bettingMoney > 0)
        {
            bettingMoney -= _bettingHistory.Pop();
            UpdateBettingText();
        }   
    }


    public void UpdateBettingText()
    {
        _bettingText.text = "Your bet amount: $" +  bettingMoney.ToString();
    }

    private bool CheckEnoughGold(int wantToBet)
    {
        return _goldManager.currentGold-bettingMoney-wantToBet > 0;
    }


}
