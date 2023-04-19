using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;
    private PlayerStatsUIScripts _playerUI;
    void Start()
    {
        _playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerStatsUIScripts>();
        
    }

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
                _playerUI.AddMoney(100);
                         
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
