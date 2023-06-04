using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startLife = 1;
    private int health;
    private GameObject generator;
    // Start is called before the first frame update
    void Start()
    {
        health = startLife;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();
    }

    public void SetGenerator(GameObject generator) {
        this.generator = generator;
    }

    public void ResetLife() {
        health = startLife;
    }

    void CheckLife() {
        if (health < 1) {
            Destroy();
        } 
    }

    public void Hitted(int damage) {
        if (health > 0) {
            health -= damage;
        }
    }

    public void Destroy() {
        ResetLife();
        generator.GetComponent<Generator>().DeleteObjFromList(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
                if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
                {
                    Hitted(bullet.damage);
                    bullet.Destroy();
                    Destroy();
                }
    }
}
