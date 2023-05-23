using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;

    [SerializeField] private IntEventSO _goldEvent;
    [SerializeField] private int _deathMoney = 33;
    private PlayerHealthManager _phm;

    // Update is called once per frame
   
    private void Start()
    {
        _phm = GameObject.Find("HealthManager").GetComponent<PlayerHealthManager>();
    }
    void Update()
    {
       // CheckScene();

        if (gameObject.tag == "Player")
        {
            healthPoints = _phm.GetCurrentHP();
        }

        if (healthPoints <= 0)
        {
            Debug.Log("Dead");
            Die();
           
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

        if (gameObject.tag == "EnemyTest")
        {
            _goldEvent.Invoke(_deathMoney);
        }
        Destroy(this.gameObject,2);
    }

    //public void CheckScene()
    //{
    //    _currerntScene = SceneManager.GetActiveScene();
    //    if (_currerntScene.buildIndex == 1)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //    else 
    //    {
    //        gameObject.SetActive(true);
    //    }
    //}
}
