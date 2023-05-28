using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoScript : MonoBehaviour
{
    public string playerName;
    [SerializeField] private int _gold;
    [SerializeField] private int _health;
    [SerializeField] private int _wantedPrice;

    private void Update()
    {
        _gold = GameObject.Find("GoldManager").GetComponent<GoldManager>().currentGold;
        _health = GameObject.Find("HealthManager").GetComponent<PlayerHealthManager>().currentHP;
    }
}
