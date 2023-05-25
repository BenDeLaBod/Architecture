using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField] private IntEventSO _hpEvent;
    [SerializeField] private IntEventSO _hpUpdateEvent;

    public int currentHP = 100;
    public int GetCurrentHP() => currentHP;

    private void Start()
    {
        _hpEvent.Event += UpdateHP;
    }
    private void OnDestroy()
    {
        _hpEvent.Event -= UpdateHP;
    }

    /// <summary>
    /// Update HP, Add the argument value to the current HP, clamp the HP to 0 and 100. 
    /// Invoke updates the HP UI display
    /// </summary>
    /// <param name="healedHP"> The assigned value gets added to the existing current HP</param>
    private void UpdateHP(int healedHP)
    {
        currentHP += healedHP;
        currentHP = Mathf.Clamp(currentHP, 0, 100);
       
        _hpUpdateEvent.Invoke(currentHP);
    }
}
