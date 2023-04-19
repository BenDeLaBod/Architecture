using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;
    private PlayerStatsUIScripts playerUI;
    void Start()
    {
        playerUI = GameObject.FindGameObjectWithTag("PlayerUI").GetComponent<PlayerStatsUIScripts>();
    }

    // Update is called once per frame
    void Update()
    {

        if(healthPoints <= 0)
        {
            Debug.Log("Dead");
            Die();
            if(gameObject.tag == "EnemyTest")
            {
                playerUI.AddMoney(100);
            }
        }
    }

    public void TakeDamage(int damageNumber)
    {
        healthPoints -= damageNumber;
        
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }
}
