using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;

    [SerializeField] private IntEventSO _hpEvent;
    [SerializeField] private int _deathMoney = 33;
    private PlayerHealthManager phm;

    // Update is called once per frame
    private void Start()
    {
        phm = GameObject.Find("HealthManager").GetComponent<PlayerHealthManager>();
    }
    void Update()
    {
        
        if(gameObject.tag == "Player")
        {
            healthPoints = phm.GetCurrentHP();
        }

        if (healthPoints <= 0)
        {
            Debug.Log("Dead");
            Die();
            if(gameObject.tag == "EnemyTest")
            {
                _hpEvent.Invoke(_deathMoney);                     
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
