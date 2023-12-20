using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fullscreen;

    [SerializeField] TextMeshProUGUI generalSound;
    [SerializeField] TextMeshProUGUI musicSound;
    [SerializeField] TextMeshProUGUI effectSound;

    [SerializeField] TMP_Dropdown    dropdown;

    [SerializeField] Slider          slideGeneral;
    [SerializeField] Slider          slideMusic;
    [SerializeField] Slider          slideEffect;

    private float   generalVolume = 1f;
    private float   musicVolume = 1f;
    private float   effectVolume = 1f;

    public void Start() {

    }

    public void Fullscreen() {
        Screen.fullScreen = !Screen.fullScreen;
        if (Screen.fullScreen)
            fullscreen.text = "On";
        else
            fullscreen.text = "Off";
    }

    public void ChangeResolution() {
        string optionSelectionnee = dropdown.options[dropdown.value].text;

        if (optionSelectionnee == "1920x1080")
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        else if (optionSelectionnee == "1280x720")
            Screen.SetResolution(1280, 720, Screen.fullScreen);
    }

    public void changeGeneralVolume() {
        generalVolume = slideGeneral.value;

        float value = generalVolume * 100;
        generalSound.text = ((int)value).ToString();
        updateAllSources();
    }

    public void changeMusicVolume() {
        musicVolume = slideMusic.value;

        float value = musicVolume * 100;
        musicSound.text = ((int)value).ToString();
        updateAllMusics();
    }

    public void changeEffectVolume() {
        effectVolume = slideEffect.value;

        float value = effectVolume * 100;
        effectSound.text = ((int)value).ToString();
        updateAllEffects();
    }

    public void updateAllEffects() {
        foreach (EffectManager em in FindObjectsOfType<EffectManager>()) {
            em.UpdateVolume(effectVolume * generalVolume);
        }
    }

    public void updateAllMusics() {
        foreach (MusicManager mm in FindObjectsOfType<MusicManager>()) {
            mm.UpdateVolume(musicVolume * generalVolume);
        }
    }

    public void updateAllSources() {
        updateAllEffects();
        updateAllMusics();
    }
}
