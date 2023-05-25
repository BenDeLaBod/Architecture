using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyChecker : MonoBehaviour
{
    public bool beenMadeEnemy;
    [SerializeField] HealthPoints _healthPointScripts;
    int _maxHP;
    private void Start()
    {
        
        _maxHP = _healthPointScripts.healthPoints;
    }
    private void Update()
    {
        if(_healthPointScripts.healthPoints <= (_maxHP / 2))
        {
            beenMadeEnemy = true;
        }
    }
    public bool CheckForEnemy()
    {
        return beenMadeEnemy;
    }
}
