using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletManager : MonoBehaviour
{
    public ObjectPool<GameObject> pool;

    private Gun gun;

    private void Start()
    {
        gun = GetComponent<Gun>();
        pool = new ObjectPool<GameObject>(
            CreateBullet,
            OnTakeBulletFromPool, 
            OnReturnBulletToPool, 
            OnDestroyBullet
            );
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(gun.projectilePrefab, gun.bulletSpawnPoint.transform.position, gun.transform.rotation);

        bullet.GetComponent<BulletScript>().SetPool(pool);

        bullet.SetActive(true);

        return bullet;
    }

    private void OnTakeBulletFromPool(GameObject bullet)
    {
        bullet.transform.position = gun.bulletSpawnPoint.transform.position;
        bullet.transform.rotation = gun.transform.rotation;

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
}
