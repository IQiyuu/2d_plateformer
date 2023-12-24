using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fullscreenTXT;

    [SerializeField] TextMeshProUGUI generalSoundTXT;
    [SerializeField] TextMeshProUGUI musicSoundTXT;
    [SerializeField] TextMeshProUGUI effectSoundTXT;

    [SerializeField] TMP_Dropdown    dropdown;

    [SerializeField] Slider          slideGeneral;
    [SerializeField] Slider          slideMusic;
    [SerializeField] Slider          slideEffect;

    private int     fullscreen;
    private float   generalVolume;
    private float   musicVolume;
    private float   effectVolume;
    private string  resolution;

    public void Start() {
        if (PlayerPrefs.HasKey("FirstLaunch"))
            loadOptions();
        else
            initOptions();
    }

    private void loadOptions() {
        fullscreen = PlayerPrefs.GetInt("Fullscreen");
        generalVolume = PlayerPrefs.GetFloat("GeneralVolume");
        effectVolume = PlayerPrefs.GetFloat("EffectVolume");
        musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        resolution = PlayerPrefs.GetString("Resolution");
    }

    private void initOptions() {
        fullscreen = 1;
        resolution = "1920x1080";
        generalVolume = 1f;
        effectVolume = 1f;
        musicVolume = 1f;

        PlayerPrefs.SetInt("Fullscreen", fullscreen);
        PlayerPrefs.Save();
        PlayerPrefs.SetString("Resolution", resolution);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("GeneralVolume", generalVolume);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
        PlayerPrefs.SetFloat("EffectVolume", effectVolume);
        PlayerPrefs.Save();
    }

    public void Fullscreen() {
        if (fullscreen == 1)
            fullscreen = 0;
        else
            fullscreen = 1;
        if (fullscreen == 1)
            fullscreenTXT.text = "On";
        else
            fullscreenTXT.text = "Off";
        PlayerPrefs.SetInt("Fullscreen", fullscreen);
        PlayerPrefs.Save();
    }

    public void ChangeResolution() {
        string resolution = dropdown.options[dropdown.value].text;

        if (resolution == "1920x1080")
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        else if (resolution == "1280x720")
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        PlayerPrefs.SetString("Resolution", resolution);
        PlayerPrefs.Save();
    }

    public void changeGeneralVolume() {
        generalVolume = slideGeneral.value;

        float value = generalVolume * 100;
        generalSoundTXT.text = ((int)value).ToString();
        updateAllSources();
        PlayerPrefs.SetFloat("GeneralVolume", generalVolume);
        PlayerPrefs.Save();
    }

    public void changeMusicVolume() {
        musicVolume = slideMusic.value;

        float value = musicVolume * 100;
        musicSoundTXT.text = ((int)value).ToString();
        updateAllMusics();
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void changeEffectVolume() {
        effectVolume = slideEffect.value;

        float value = effectVolume * 100;
        effectSoundTXT.text = ((int)value).ToString();
        updateAllEffects();
        PlayerPrefs.SetFloat("EffectVolume", effectVolume);
        PlayerPrefs.Save();
    }

    public void updateAllEffects() {
        EffectManager[] effects = FindObjectsOfType<EffectManager>();
        foreach (EffectManager em in effects) {
            em.UpdateVolume(effectVolume * generalVolume);
        }
    }

    public void updateAllMusics() {
        MusicManager[] music = FindObjectsOfType<MusicManager>();
        foreach (MusicManager mm in music) {
            mm.UpdateVolume(musicVolume * generalVolume);
        }
    }

    public void updateAllSources() {
        updateAllEffects();
        updateAllMusics();
    }
}
