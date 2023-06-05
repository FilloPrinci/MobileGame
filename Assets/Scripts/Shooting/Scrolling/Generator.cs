using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public bool recycleGeneratedGameObjects = false;
    public bool randomizeX = false;
    [Range(1, 10f)]
    public int randomRange;
    public GameObject generator;
    public GameObject spawner;
    public GameObject toBeSpawned;
    public int gridSize = 1;
    public int rangeX = 2;
    public int rangeZ = 1;
    public int maxSpawnedObjs = 0;
    public GameObject gameManager;

    private GameObject[,] generatedObjects;
    private List<GameObject> spawnedObjs;
    private List<GameObject> disabledSpawnedObjects;
    private bool limitSpawnedObjs = false;

    private void Start()
    {
        if (recycleGeneratedGameObjects) {
            int rows = (rangeZ * 2) + 1;
            int columns = (rangeX * 2) + 1;
            generatedObjects = new GameObject[columns, rows];
            Generate();
        }
    }
     
    private void Update()
    {
        SnapPosition();
    }

    void SnapPosition() {
        Vector3 newPosition = new Vector3(Trunk(generator.transform.position.x / gridSize) * gridSize, Trunk(generator.transform.position.y / gridSize) * gridSize, Trunk(generator.transform.position.z / gridSize) * gridSize);
        
        
        if (newPosition != spawner.transform.position) {
            spawner.transform.position = newPosition;
            if (recycleGeneratedGameObjects)
            {
                RefreshGeneration();
            }
            else {
                    if (spawnedObjs == null || (limitSpawnedObjs && spawnedObjs.Count < maxSpawnedObjs))
                    {
                        Generate();
                    }                
            }
        }
        
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

    void RefreshGeneration() {
        int rows = (rangeZ * 2) + 1;
        int columns = (rangeX * 2) + 1;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                generatedObjects[i, j].transform.position = new Vector3(spawner.transform.position.x + ((i - Trunk(columns / 2)) * gridSize), spawner.transform.position.y, spawner.transform.position.z + ((j - Trunk(rows / 2)) * gridSize));
            }
                
        }
    }

    void Generate() {
        int rows = (rangeZ * 2) + 1;
        int columns = (rangeX * 2) + 1;

        for (int i = 0; i < columns; i++)
        {
            for (int j = 0; j < rows; j++) {

                Vector3 newPosition = new Vector3(spawner.transform.position.x + ((i - Trunk(columns / 2)) * gridSize), spawner.transform.position.y, spawner.transform.position.z + ((j - Trunk(rows / 2)) * gridSize));

                if (recycleGeneratedGameObjects)
                {
                    generatedObjects[i, j] = Spawn(newPosition, columns, rows, i, j);

                }
                else if(limitSpawnedObjs){
                    spawnedObjs.Add(Spawn(newPosition, columns, rows, i, j));
                }
            }
        }
    }

    GameObject Spawn(Vector3 newPosition, int columns, int rows, int x, int y) {

        int randomXOffset = 0;

        if (randomizeX) {
            randomXOffset = Random.Range(-randomRange, randomRange +1);
        }

        GameObject newObj;

        if (limitSpawnedObjs && disabledSpawnedObjects.Count > 0)
        {
            newObj = disabledSpawnedObjects[disabledSpawnedObjects.Count - 1];
            disabledSpawnedObjects.Remove(newObj);
            newObj.transform.position = new Vector3(newPosition.x + ((x - Trunk(columns / 2)) * gridSize) + (randomXOffset * gridSize), newPosition.y, newPosition.z + ((y - Trunk(rows / 2)) * gridSize));
            newObj.SetActive(true);
        }
        else {
            newObj = Instantiate(toBeSpawned, new Vector3(newPosition.x + ((x - Trunk(columns / 2)) * gridSize) + (randomXOffset * gridSize), newPosition.y, newPosition.z + ((y - Trunk(rows / 2)) * gridSize)), Quaternion.identity);
        }

        return newObj;
    }

    public void DeleteObjFromList(GameObject obj) {
        spawnedObjs.Remove(obj);
        if (limitSpawnedObjs) {
            obj.SetActive(false);
            disabledSpawnedObjects.Add(obj);
        }
    }
}
