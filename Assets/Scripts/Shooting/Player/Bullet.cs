using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    private GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }

    public void SetGenerator(GameObject generator)
    {
        this.generator = generator;
    }


    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<ObjType>(out ObjType objType))
        {
            if (objType.type == TypeEnum.Destroyable)
            {
                if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                {
                    enemy.Hitted(damage);
                    Destroy();
                }
            }
        }
    }*/

    public void Destroy()
    {
        generator.GetComponent<PlayerController>().RemoveBullet(this.gameObject);
    }
}
