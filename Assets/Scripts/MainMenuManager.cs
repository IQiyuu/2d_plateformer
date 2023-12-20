using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
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
        SceneManager.LoadScene("GameMenu");
    }

    public void OpenOption() {
        panelMain.SetActive(false);
        panelOptions.SetActive(true);
        panelAffichage.SetActive(true);
    }

    public void CloseOptions() {
        DisableAllOptPanel();
        panelOptions.SetActive(false);
        panelMain.SetActive(true);
    }

    public void AudioOption() {
        DisableAllOptPanel();
        panelAudio.SetActive(true);
    }

    public void AffichageOption() {
        DisableAllOptPanel();
        panelAffichage.SetActive(true);
    }

    public void ControlsOption() {
        DisableAllOptPanel();
        panelControls.SetActive(true);
    }

    public void LangageOption() {
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
