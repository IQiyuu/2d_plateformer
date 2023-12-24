using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] EffectManager buttonPress;

    [SerializeField] Button buttonContinue;

    [SerializeField] GameObject panelMain;
    [SerializeField] GameObject panelOptions;
    [SerializeField] GameObject panelAudio;
    [SerializeField] GameObject panelAffichage;
    [SerializeField] GameObject panelControls;
    [SerializeField] GameObject panelLang;

    public void Start() {
        buttonContinue.interactable = false;
        panelOptions.SetActive(false);
        panelMain.SetActive(true);
        DisableAllOptPanel();
    }

    public void ExitGame() {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void StartGame() {
        buttonPress.playSound();
        SceneManager.LoadScene("GameMenu");
    }

    public void OpenOption() {
        buttonPress.playSound();
        panelMain.SetActive(false);
        panelOptions.SetActive(true);
        panelAffichage.SetActive(true);
    }

    public void CloseOptions() {
        buttonPress.playSound();
        DisableAllOptPanel();
        panelOptions.SetActive(false);
        panelMain.SetActive(true);
    }

    public void AudioOption() {
        buttonPress.playSound();
        DisableAllOptPanel();
        panelAudio.SetActive(true);
    }

    public void AffichageOption() {
        buttonPress.playSound();
        DisableAllOptPanel();
        panelAffichage.SetActive(true);
    }

    public void ControlsOption() {
        buttonPress.playSound();
        DisableAllOptPanel();
        panelControls.SetActive(true);
    }

    public void LangageOption() {
        buttonPress.playSound();
        DisableAllOptPanel();
        panelLang.SetActive(true);
    }

    private void DisableAllOptPanel() {
        panelAffichage.SetActive(false);
        panelAudio.SetActive(false);
        panelControls.SetActive(false);
        panelLang.SetActive(false);
    }
}
