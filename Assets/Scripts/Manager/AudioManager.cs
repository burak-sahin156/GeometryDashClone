using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviourSingletonPersistent<AudioManager>
{
    [SerializeField] AudioMixer GameMixer;
    [SerializeField] public AudioSource MusicMixer;
    public const string MUSIC_KEY = "musicVolume";

    public void LoadVolumes()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 0.5f);
        GameMixer.SetFloat(VolumeSettings.MIXER_MUSIC, Mathf.Log10(musicVolume) * 20);
    }

}
