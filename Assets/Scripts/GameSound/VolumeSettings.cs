using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider musicSlider;

    public const string MIXER_MUSIC = "MusicVolume";
    private void Awake()
    {
        musicSlider.onValueChanged.AddListener(SetGameMusicVolume);
    }
    private void Start()
    {
        float volume = PlayerPrefs.GetFloat(MIXER_MUSIC);
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, volume);
    }
    public void SetGameMusicVolume(float volume)
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(volume) * 20f);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(MIXER_MUSIC, musicSlider.value);
    }
}
