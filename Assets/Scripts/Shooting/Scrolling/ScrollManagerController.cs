using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollManagerController : MonoBehaviour
{
    public float scrollingSpeed = 1;
    public Vector3 direction = Vector3.back;
    public GameObject volumeChecker;
    public GameObject[] objectsToMove;
    public Transform spawnPoint;

    private float deltaTime = 0;

    private List<GameObject> generatedObjs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime = Time.deltaTime;

        MoveObjectsForward();
    }

    void MoveObjectsForward() {

        for (int i = 0; i < objectsToMove.Length; i++) {
            objectsToMove[i].transform.position += direction * scrollingSpeed * deltaTime;
        }
    }

        
}

