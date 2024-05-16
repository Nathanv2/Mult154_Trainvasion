using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class VolumeControl : MonoBehaviour
{
    public static VolumeControl instance;

    public Slider masterVolume;
    public Slider musicVolume;
    public Slider sfxVolume;

    public AudioSource[] masterSource;
    public AudioSource[] musicSource;
    public AudioSource[] sfxSource;

    public GameManager gameManager;


    private void Awake()
    {
        //checks if intance exists
        if (instance == null)
        {
            instance = this;
        }
        //if an intance of the gameManager already exists on a scene destroy it
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //wont be destroyed between changing scenes
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        gameManager = gameManager = FindObjectOfType<GameManager>();
        UpdateVolumes();

        masterVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        musicVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });
        sfxVolume.onValueChanged.AddListener(delegate { OnVolumeChanged(); });

        musicVolume.onValueChanged.AddListener(delegate { OnVolumeChanged2(); });
        sfxVolume.onValueChanged.AddListener(delegate { OnVolumeChanged2(); });

    }

    void Update()
    {
        if(gameManager == null)
        {
            gameManager = gameManager = FindObjectOfType<GameManager>();
        }
        else if (masterVolume == null)
        {
            masterVolume = GameObject.FindWithTag("Master Slider").GetComponent<Slider>();
        }
        else if (musicVolume == null)
        {
            musicVolume = GameObject.FindWithTag("Music Slider").GetComponent<Slider>();
        }
        else if (sfxVolume == null)
        {
            sfxVolume = GameObject.FindWithTag("SFX Slider").GetComponent<Slider>();
        }

        for (int i = 0; i < masterSource.Length; i++)
        {
            if (masterSource[i] == null)
            {
                GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

                if (musicObjects.Length > 0)
                {
                    if (i < musicObjects.Length)
                    {
                        AudioSource audioSource = musicObjects[i].GetComponent<AudioSource>();

                        if (audioSource != null)
                        {
                            masterSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 0; i < masterSource.Length; i++)
        {
            if (masterSource[i] == null)
            {
                GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("SFX");

                if (sfxObjects.Length > 0)
                {
                    if (i < sfxObjects.Length)
                    {        
                        AudioSource audioSource = sfxObjects[i].GetComponent<AudioSource>();

                        if (audioSource != null)
                        {
                            masterSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

        }



        for (int i = 0; i < musicSource.Length; i++)
        {
            if (musicSource[i] == null)
            {
                GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

                if (musicObjects.Length > 0)
                {
                    if (i < musicObjects.Length)
                    {
                        AudioSource audioSource = musicObjects[i].GetComponent<AudioSource>();

                        if (audioSource != null)
                        {
                            musicSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        for (int i = 0; i < sfxSource.Length; i++)
        {
            if (sfxSource[i] == null)
            {
                GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("SFX");

                if (sfxObjects.Length > 0)
                {
                    if (i < sfxObjects.Length)
                    {
                        AudioSource audioSource = sfxObjects[i].GetComponent<AudioSource>();

                        if (audioSource != null)
                        {
                            sfxSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }


        UpdateVolumeValues();

    }

    void UpdateVolumeValues()
    {
        for (int i = 0; i < sfxSource.Length; i++)
        {
            if (sfxSource[i] != null)
            {
                sfxSource[i].volume = sfxVolume.value;
            }
        }

        for (int i = 0; i < musicSource.Length; i++)
        {
            if (musicSource[i] != null)
            {
                musicSource[i].volume = musicVolume.value;
            }
        }
    }
    void UpdateVolumes()
    {

        float masterValue = masterVolume.value;

        // Adjust volume for music sources
        for (int i = 0; i < musicSource.Length; i++)
        {
            if (musicSource[i] != null)
            {
                musicSource[i].volume = masterValue;
            }
        }

        // Adjust volume for sfx sources
        for (int i = 0; i < sfxSource.Length; i++)
        {
            if (sfxSource[i] != null)
            {
                sfxSource[i].volume = masterValue;
            }
        }
    }

    void OnVolumeChanged()
    {
        UpdateVolumes();
    }

    void OnVolumeChanged2()
    {
        for (int i = 0; i < masterSource.Length; i++)
        {
            masterSource[i].volume = masterVolume.value;
        }

        for (int i = 0; i < musicSource.Length; i++)
        {
            musicSource[i].volume = musicVolume.value;
        }

        for (int i = 0; i < sfxSource.Length; i++)
        {
            sfxSource[i].volume = sfxVolume.value;
        }
    }

}
