using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public GameObject generator;
    public bool front = false;

    void OnCollisionEnter(Collision collision)
    {
        if (front)
        {
            if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
            {
                bullet.Destroy();
            }
        }
        else {
            
            if (collision.gameObject.TryGetComponent<ObjType>(out ObjType objType))
            {
                Debug.Log("Gameobject has ObjType class");
                if (objType.type == TypeEnum.Destroyable)
                {
                    Debug.Log("Gameobject is destroyable");

                    if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                    {
                        enemy.Destroy();
                    }

                }
            }
        }
        
        
    }
}
