using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;

    [SerializeField]
    private GameObject bulletPrefab;

    [SerializeField]
    private int poolMax;

    private void Start()
    {
        pool = new ObjectPool<GameObject>(
            CreateBullet,
            OnTakeBulletFromPool, 
            OnReturnBulletToPool, 
            OnDestroyBullet,
            true, 4, poolMax
            );
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform);

        bullet.SetActive(false);

        return bullet;
    }

    private void OnTakeBulletFromPool(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    private void OnReturnBulletToPool(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    private void OnDestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }

    public GameObject GetBullet()
    {
        return pool.Get();
    }
    public void ReturnBullet(GameObject bullet)
    {
        pool.Release(bullet);
    }
}
