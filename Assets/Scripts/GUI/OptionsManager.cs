using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public const string VOLUME_PARAM_NAME = "MasterVolume";

    public Slider volumeSlider;
    public Slider difficultySlider;

    public float difficultySliderValueDefault = 1;
    public float volumeSliderValueDefault = -12;

    public static float difficultyLevel = 1;

    private void Start()
    {
        var canGetVolume= audioMixer.GetFloat(VOLUME_PARAM_NAME, out var volume);

        if (canGetVolume)
            volumeSlider.value = volume;
        else
            Debug.LogWarning("Cannot get volume value from the audio mixer");

        difficultySlider.value = difficultyLevel;
    }

    public void ChangeVolume()
    {
        var volumeValue = volumeSlider.value;

        audioMixer.SetFloat(VOLUME_PARAM_NAME, volumeValue);
    }

    public void ChangeDifficulty()
    {
        difficultyLevel = difficultySlider.value;
    }

    public void SetDefaults()
    {
        difficultyLevel = difficultySliderValueDefault;
        difficultySlider.value = difficultySliderValueDefault;

        volumeSlider.value = volumeSliderValueDefault;
        audioMixer.SetFloat(VOLUME_PARAM_NAME, volumeSliderValueDefault);
        PlayerPrefsController.SetMasterVolume(volumeSliderValueDefault);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);

        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }
}
