using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public GameObject body;
    public float rotationSpeed;
    public Vector3 rotation;

    // Update is called once per frame
    void Update()
    {
        body.transform.Rotate(rotation * rotationSpeed * Time.deltaTime);
    }
}
