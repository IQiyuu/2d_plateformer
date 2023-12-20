using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI fullscreen;
    [SerializeField] TMP_Dropdown    dropdown;

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
}
