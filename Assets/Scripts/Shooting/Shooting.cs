using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulet;

    [Range(0.1f, 2f)]
    public float fireRate = 1;

    public int maxBullets = 50;
    
    private GameObject bulletObjPool;
    private ObjectPool bulletPool;
    private bool retryPool = false;

    private void Awake()
    {
        bulletObjPool = new GameObject();
        bulletObjPool.AddComponent<ObjectPool>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = bulletObjPool.GetComponent<ObjectPool>();
        bulletPool.objectToPool = bulet;
        bulletPool.amountToPool = maxBullets;

        bulletPool.Instantiate();

        if (bulletPool.pooledObjects != null) {
            Debug.Log("bulletPool.pooledObjects != null");
            StartCoroutine(ShootingOverRate(fireRate));

        }
        else
        {
            retryPool = true;
        }
    }

    void Shoot()
    {
        GameObject spawnedObj = bulletPool.GetPooledObject();
        if (spawnedObj != null)
        {
            spawnedObj.transform.position = transform.position;
            spawnedObj.transform.rotation = transform.rotation;
            spawnedObj.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        if (retryPool)
        {
            if (bulletPool.pooledObjects != null)
            {
                StartCoroutine(ShootingOverRate(fireRate));
                retryPool = false;
            }
        }
    }

    IEnumerator ShootingOverRate(float rate)
    {
        for (; ; )
        {
            Shoot();
            yield return new WaitForSeconds(rate);
        }
    }
}
