using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int startLife = 1;
    private int health;
    private GameObject gameManager;
    public int pointsValue = 10;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        health = startLife;
        SetGameManager(GameObject.Find("GameManager"));
    }

    public void SetGameManager(GameObject gameManager)
    {
        this.gameManager = gameManager;
    }

    public void ResetLife() {
        health = startLife;
    }

    void CheckLife() {
        if (health < 1) {
            gameManager.GetComponent<GameManager>().AddPoints(pointsValue);
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
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
                if (collision.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
                {
                    Hitted(bullet.damage);
                    bullet.Destroy();
                    CheckLife();
                }
    }
}
