using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _bulletSpeed = 10;
    float _lifeSpan = 2.5f;

    Vector3 direction;
    
    void Start()
    {
        direction = transform.forward;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  Time.deltaTime * _bulletSpeed * direction;
        _lifeSpan -= Time.deltaTime;

        if(_lifeSpan <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnCollisionEnter(Collision targetHit)
    {
        if (!targetHit.gameObject.CompareTag("Gun"))
        {
            if (targetHit.gameObject.CompareTag("EnemyTest"))
            {
                Debug.Log("Enemy Hit");
                targetHit.gameObject.GetComponent<HealthPoints>().TakeDamage(1);
            }

            Destroy(gameObject);
        }
    }
}



