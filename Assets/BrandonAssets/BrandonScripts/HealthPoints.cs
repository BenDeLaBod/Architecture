using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HealthPoints : MonoBehaviour
{
    // Start is called before the first frame update
    public int healthPoints;
    [SerializeField] Animator _anim;
    [SerializeField] private IntEventSO _goldEvent;
    [SerializeField] public int deathMoney = 33;
    private PlayerHealthManager _phm;
    bool alive;

    // Update is called once per frame
   
    private void Start()
    {
        alive = true;
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
            //Send message using the event
            _goldEvent.Invoke(deathMoney);
        }
        _anim.SetBool("Died", true);
        Destroy(this.gameObject,2.5f);
    }

    public void GetAnimator(Animator anim)
    {
        _anim = anim;
    }
}
