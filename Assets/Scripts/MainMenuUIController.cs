using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    public string shooterScene;

    public void LoadShooterScene() {
        SceneManager.LoadScene(shooterScene, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

}
