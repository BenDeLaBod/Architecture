using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private IntEventSO _hpEvent;
    [SerializeField] private IntEventSO _hpUpdateEvent;

    public int _currentHP = 100;

    private void Start()
    {
        _hpEvent.Event += UpdateHP;
    }
    private void OnDestroy()
    {
        _hpEvent.Event -= UpdateHP;
    }

    private void UpdateHP(int healedHP)
    {
        _currentHP += healedHP;
        _currentHP = Mathf.Clamp(_currentHP, 0, 100);
        _hpUpdateEvent.Invoke(_currentHP);
    }

    

}
