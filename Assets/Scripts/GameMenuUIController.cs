using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuUIController : MonoBehaviour
{
    public string playScene = "";
    private string mainMenuScene = "MainMenu";

    public void Quit()
    {
        Application.Quit();
    }

    public void PlayGame() {
        SceneManager.LoadScene(playScene, LoadSceneMode.Single);
    }
}
