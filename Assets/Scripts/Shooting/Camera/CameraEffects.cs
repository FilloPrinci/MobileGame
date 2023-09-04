using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEffects : MonoBehaviour
{

    public float cameraShakeMagnitude = 0.5f;
    public float cameraShakeDuration = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CameraShake()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake ()
    {
        Vector3 originalPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < cameraShakeDuration) {
            float x = Random.Range(-1f, 1f) * cameraShakeMagnitude;

            transform.localPosition += new Vector3(x, 0, 0);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = originalPos;
    }
}
