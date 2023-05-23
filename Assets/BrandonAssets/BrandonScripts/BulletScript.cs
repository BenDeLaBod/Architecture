using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float _bulletSpeed = 20;
    float _lifeSpan = 2.5f;
    float timer;

    Vector3 direction;

    private ObjectPool<GameObject> _objectPool;
    
    void Start()
    {
        
        //Destroy(gameObject, _lifeSpan);
    }

    private void OnEnable()
    {
        direction = transform.forward;
        timer = _lifeSpan;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position +=  Time.deltaTime * _bulletSpeed * direction;
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            _objectPool.Release(gameObject);
        }
    }
   

    private void OnTriggerEnter(Collider targetHit)
    {
        if (!targetHit.gameObject.CompareTag("Gun"))
        {
            if (targetHit.gameObject.CompareTag("EnemyTest"))
            {
                Debug.Log("Enemy Hit");
                targetHit.gameObject.GetComponent<HealthPoints>().TakeDamage(1);
            }

            _objectPool.Release(gameObject);
        }
    }

    public void SetPool(ObjectPool<GameObject> pool)
    {
        _objectPool = pool;
    }


}



