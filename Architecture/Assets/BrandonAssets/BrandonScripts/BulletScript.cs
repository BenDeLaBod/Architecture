using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float bulletSpeed = 10;
    float lifeSpan = 2.5f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
        lifeSpan -= Time.deltaTime;

        if(lifeSpan <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnCollisionEnter(Collision targetHit)
    {
        if (targetHit.gameObject.CompareTag("EnemyTest"))
        {
            Destroy(this.gameObject);
            Debug.Log("Enemy Hit");
            targetHit.gameObject.GetComponent<HealthPoints>().TakeDamage(1);
            
        }
    }
}



