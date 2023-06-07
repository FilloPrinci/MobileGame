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
    public UniversalRenderPipelineAsset renderPipelineAsset;

    public int FPS_Target;
    public float Resolution_Scale;

    private void Start()
    {
        Resolution_Scale = renderPipelineAsset.renderScale;
        resolutionScaleSlider.value = Resolution_Scale * 10;
        resolutionScaleText.text = (resolutionScaleSlider.value / 10).ToString();
        FPS_TargetSlider.value = Application.targetFrameRate / 30;
        FPS_TargetText.text = Application.targetFrameRate.ToString();
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
    }

    public void SetFPSTarget() {
        float sliderValue = FPS_TargetSlider.value;
        float newFPS_Target = sliderValue * 30;
        FPS_TargetText.text = newFPS_Target.ToString();
        Application.targetFrameRate = (int)newFPS_Target;
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

    public void Quit()
    {
        Application.Quit();
    }
}
