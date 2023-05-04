using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class BettingScript : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _bettingText;
    [SerializeField] public double bettingMoney;
    [SerializeField] public double lastBet;
    Stack<int> _bettingHistory = new Stack<int>();

    public void Add5()
    {
        //ActionBase action = new Add5Dollar(this);

        //_bettingRecorder.Record(action);

        bettingMoney += 5f;
        UpdateBettingText();
        lastBet = 5;
        _bettingHistory.Push(5);
    }
    public void Add10()
    {

        bettingMoney += 10f;
        UpdateBettingText();
        lastBet = 10f;
        _bettingHistory.Push(10);
    }
    public void Add20()
    {

        bettingMoney += 20f;
        UpdateBettingText();
        lastBet = 20;
        _bettingHistory.Push(20);
    }
    public void Add50()
    {
        bettingMoney += 50f;
        UpdateBettingText();
        lastBet = 50;
        _bettingHistory.Push(50);
    }
    public void Add100()
    {

        bettingMoney += 100f;
        UpdateBettingText();
        lastBet = 100;
        _bettingHistory.Push(100);
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
        //_bettingMoney *= 0.5f;
        _bettingText.text = "Your bet amount: $" +  bettingMoney.ToString();
    }

}
