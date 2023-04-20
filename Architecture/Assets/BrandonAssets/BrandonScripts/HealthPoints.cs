using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;

    [SerializeField] private IntEventSO _scoreEvent;
    [SerializeField] private int _deathMoney = 33;

    // Update is called once per frame
    void Update()
    {
        healthPoints = Mathf.Clamp(healthPoints, 0, 100);
        if (healthPoints <= 0)
        {
            Debug.Log("Dead");
            Die();
            if(gameObject.tag == "EnemyTest")
            {
                _scoreEvent.Invoke(_deathMoney);                     
            }
        }
    }

    public void TakeDamage(int damageNumber)
    {
        healthPoints -= damageNumber;    
    }

    public void HealHP(int amountHeal)
    {
        healthPoints += amountHeal;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
