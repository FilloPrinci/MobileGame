using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI gameOverPoints;
    public Text pointsText;
    private int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        pointsText.text = "Points: " + points;
    }

    public void SetPoints(int points) {
        this.points = points;
        pointsText.text = "Points: " + points;
    }

    public void AddPoints(int points)
    {
        SetPoints(this.points += points);
        
    }

    public int GetPoints() {
        return this.points;
    }

    public void GameOver() {
        Time.timeScale = 0;
        gameOverPoints.text = "Points : " + points.ToString();
        gameOverPanel.SetActive(true);
    }

    public void SetVsync1() { QualitySettings.vSyncCount = 1; Application.targetFrameRate = -1; }
    public void SetVsync2() { QualitySettings.vSyncCount = 2; Application.targetFrameRate = -1; }
    public void SetVsync0_Default() { QualitySettings.vSyncCount = 0; Application.targetFrameRate = -1; }
    public void SetVsync0_60FPS() { QualitySettings.vSyncCount = 0; Application.targetFrameRate = 60; }
    public void SetVsync0_120FPS() { QualitySettings.vSyncCount = 0; Application.targetFrameRate = 120; }

}
