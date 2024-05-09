using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControl : MonoBehaviour
{
    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;
    public AudioSource masterSource;
    public AudioSource musicSource;
    public AudioSource sfxSource;
    // Start is called before the first frame update
    void Start()
    {
        masterSource.volume = masterVolume.value;
        musicVolume.value = musicVolume.value;
        sfxVolume.value = sfxVolume.value;

        masterVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        musicVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        sfxVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });

        musicVolume.onValueChanged.AddListener(delegate { OnVolumeChanged2(); });
        sfxVolume.onValueChanged.AddListener(delegate { OnVolumeChanged2(); });
    }

    void OnVolumeChanged()
    {
        masterSource.volume = masterVolume.value;
        musicSource.volume = masterVolume.value;
        sfxSource.volume = masterVolume.value;
    }
    void OnVolumeChanged2()
    {
        musicSource.volume = musicVolume.value;
        sfxSource.volume = sfxVolume.value;
    }

}
