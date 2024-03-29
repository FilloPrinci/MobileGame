using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    /// <summary>
    /// healthBars LtR
    /// </summary>
    public GameObject[] healthBars;

    public GameObject mainCamera;
    public GameObject gameManager;
    public int maxHealth = 3;
    private int health;
    private bool invincibile = false;
    private int ITime = 1;

    void Start()
    {
        health = maxHealth;
    }

    public void ResetLife()
    {
        health = maxHealth;
    }

    public void SetHealthbars() {
        ResetHealthBars();
        for (int i = 0; i < health; i++) {
            healthBars[i].SetActive(true);
        }
    }

    void ResetHealthBars() { 
        for(int i = 0; i < maxHealth; i++)
        {
            healthBars[i].SetActive(false);
        }
    }

    void CheckLife()
    {
        if (health < 1)
        {
            gameManager.GetComponent<GameManager>().GameOver();
        }
        else {
            SetHealthbars();
        }
    }

    public void Hitted(int damage)
    {
        mainCamera.GetComponent<CameraEffects>().CameraShake();
        if (health > 0)
        {
            health -= damage;
            invincibile = true;
            StartCoroutine(InvincibleState());
        }
    }

    public void Destroy()
    {
        ResetLife();
        gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!invincibile) {
            if (collision.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
            {
                Hitted(enemy.damage);
                CheckLife();
            }
        }
    }

    IEnumerator InvincibleState()
    {
            new WaitForSeconds(ITime);
            invincibile = false;
            yield return null;
    }
}
