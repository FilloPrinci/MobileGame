using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;
public class InGameUIManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    public GameObject pauseButton;
    public TextMeshProUGUI resolutionScaleText;
    public Slider resolutionScaleSlider;
    public TextMeshProUGUI FPS_TargetText;
    public Slider FPS_TargetSlider;
    public Toggle ShowFPS_Toggle;
    public UniversalRenderPipelineAsset renderPipelineAsset;
    public string shooterScene;

    public int FPS_Target;
    public float Resolution_Scale;
    public bool showFPS;

    private void Start()
    {
        Resolution_Scale = PlayerPrefs.GetFloat("ResolutionScale", renderPipelineAsset.renderScale);
        resolutionScaleSlider.value = Resolution_Scale * 10;
        resolutionScaleText.text = (resolutionScaleSlider.value / 10).ToString();
        FPS_Target = PlayerPrefs.GetInt("FPS_Target", Application.targetFrameRate);
        FPS_TargetSlider.value = FPS_Target / 30;
        FPS_TargetText.text = FPS_Target.ToString();
        showFPS = PlayerPrefs.GetInt("ShowFps", 0) == 1;
    }

    public void OpenPauseMenu()
    {
        //Pause the game
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    //Pause

    public void Resume()
    {
        //Resume the game
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        pausePanel.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }


    //Settings

    public void SetResolutionScale() {
        float sliderValue = resolutionScaleSlider.value;
        float newScale = sliderValue / 10;
        resolutionScaleText.text = newScale.ToString();
        renderPipelineAsset.renderScale = newScale;
        PlayerPrefs.SetFloat("ResolutionScale", newScale);
    }

    public void SetFPSTarget() {
        float sliderValue = FPS_TargetSlider.value;
        float newFPS_Target = sliderValue * 30;
        FPS_TargetText.text = newFPS_Target.ToString();
        Application.targetFrameRate = (int)newFPS_Target;
        PlayerPrefs.SetInt("FPS_Target", (int)newFPS_Target);
    }

    public void ToggleFPSLabel() {
        showFPS = ShowFPS_Toggle.isOn;
        if (showFPS)
        {
            // Show Fps
        }
        else {
            // Hide Fps
        }

        PlayerPrefs.SetInt("ShowFps", showFPS ? 1 : 0);
    }

    public void CloseSettings() {
        settingsPanel.SetActive(false);
    }

    //GameOver

    public void Retry() {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name, LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void MainMenu() {
        SceneManager.LoadScene(shooterScene, LoadSceneMode.Single);
        Time.timeScale = 1;

    }
}
