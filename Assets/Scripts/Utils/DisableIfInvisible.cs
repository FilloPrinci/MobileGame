using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableIfInvisible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("OutOfCamera")) {
            gameObject.SetActive(false);
        }
    }
}
