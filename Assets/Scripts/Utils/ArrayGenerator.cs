using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayGenerator : MonoBehaviour
{
    public GameObject objectPool;
    
    public int Xsize = 1;
    public int Zsize = 1;

    public int perSpawnZAmount = 1;

    public bool startOnZero = false;

    public bool randomise = false;
    [Range(1, 10f)]
    public int randomRange;

    public int frameInterval = 1;

    private Transform generator;
    private Transform spawner;
    private ObjectPool pool;

    // Start is called before the first frame update
    void Start()
    {
        pool = objectPool.GetComponent<ObjectPool>();
        generator = this.transform;
        GameObject spawnerObj = new GameObject();
        spawner = spawnerObj.transform;

        if (startOnZero)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.frameCount % frameInterval == 0) {
            SnapSpawner();
        }
    }

    void SnapSpawner() {

        Vector3 newPosition = new Vector3(NextInt(generator.transform.position.x / Xsize) * Xsize, generator.transform.position.y, NextInt(generator.transform.position.z / Zsize) * Zsize);

        if (newPosition.z % (perSpawnZAmount * Zsize) == 0) {
            if (newPosition != spawner.transform.position)
            {
                spawner.transform.position = newPosition;
                Spawn();
            }
        }
    }

    float NextInt(float x) {
        float nextInt = 0;
        

        float sign = Mathf.Sign(x);
        float abs = Mathf.Abs(x);

        float trunk = Trunk(abs);

        if (sign == 1)
        {
            if (x % 1 != 0)
            {
                nextInt = trunk +  1;
            }
        }
        else
        {
            nextInt = trunk;
        }

        return nextInt;
    }

    float Trunk(float x)
    {
        

        if (x % 1 != 0)
        {
            return x - (x % 1);
        }
        else
        {
            return x;
        }

    }

    void Spawn() {

        int randomXOffset = 0;

        if (randomise) {
            randomXOffset = Random.Range(-randomRange, randomRange + 1);
        }
        
        for (int i = 0; i < perSpawnZAmount; i++) {
            GameObject spawnedObj = pool.GetPooledObject();
            if (spawnedObj != null)
            {
                Vector3 newPosition = new Vector3(spawner.position.x + (randomXOffset * Xsize), spawner.position.y, spawner.position.z + (i * Zsize));
                spawnedObj.transform.position = newPosition;
                spawnedObj.transform.rotation = spawner.rotation;
                spawnedObj.SetActive(true);
            }
        }
        
    }
}
