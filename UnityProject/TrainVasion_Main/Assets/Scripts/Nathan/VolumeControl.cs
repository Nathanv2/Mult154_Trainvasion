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
            // Check if the current index is null
            if (masterSource[i] == null)
            {
                // Find GameObjects with AudioSource component
                GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

                // Check if any GameObjects were found
                if (musicObjects.Length > 0)
                {
                    // Check if the index is within the bounds of the sfxObjects array
                    if (i < musicObjects.Length)
                    {
                        // Get the AudioSource component from the GameObject
                        AudioSource audioSource = musicObjects[i].GetComponent<AudioSource>();

                        // Assign AudioSource to sfxSource[i] if found
                        if (audioSource != null)
                        {
                            masterSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        // If the index is out of bounds, break the loop
                        break;
                    }
                }
                else
                {
                    // If no GameObjects were found, break the loop
                    break;
                }
            }
        }

        for (int i = 0; i < masterSource.Length; i++)
        {
            // Check if the current index is null
            if (masterSource[i] == null)
            {
                // Find GameObjects with AudioSource component
                GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("SFX");

                // Check if any GameObjects were found
                if (sfxObjects.Length > 0)
                {
                    // Check if the index is within the bounds of the sfxObjects array
                    if (i < sfxObjects.Length)
                    {
                        // Get the AudioSource component from the GameObject                
                        AudioSource audioSource = sfxObjects[i].GetComponent<AudioSource>();

                        // Assign AudioSource to sfxSource[i] if found
                        if (audioSource != null)
                        {
                            masterSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        // If the index is out of bounds, break the loop
                        break;
                    }
                }
                else
                {
                    // If no GameObjects were found, break the loop
                    break;
                }
            }

        }



        for (int i = 0; i < musicSource.Length; i++)
        {
            // Check if the current index is null
            if (musicSource[i] == null)
            {
                // Find GameObjects with AudioSource component
                GameObject[] musicObjects = GameObject.FindGameObjectsWithTag("Music");

                // Check if any GameObjects were found
                if (musicObjects.Length > 0)
                {
                    // Check if the index is within the bounds of the sfxObjects array
                    if (i < musicObjects.Length)
                    {
                        // Get the AudioSource component from the GameObject
                        AudioSource audioSource = musicObjects[i].GetComponent<AudioSource>();

                        // Assign AudioSource to sfxSource[i] if found
                        if (audioSource != null)
                        {
                            musicSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        // If the index is out of bounds, break the loop
                        break;
                    }
                }
                else
                {
                    // If no GameObjects were found, break the loop
                    break;
                }
            }
        }

        for (int i = 0; i < sfxSource.Length; i++)
        {
            // Check if the current index is null
            if (sfxSource[i] == null)
            {
                // Find GameObjects with AudioSource component
                GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("SFX");

                // Check if any GameObjects were found
                if (sfxObjects.Length > 0)
                {
                    // Check if the index is within the bounds of the sfxObjects array
                    if (i < sfxObjects.Length)
                    {
                        // Get the AudioSource component from the GameObject
                        AudioSource audioSource = sfxObjects[i].GetComponent<AudioSource>();

                        // Assign AudioSource to sfxSource[i] if found
                        if (audioSource != null)
                        {
                            sfxSource[i] = audioSource;
                        }
                    }
                    else
                    {
                        // If the index is out of bounds, break the loop
                        break;
                    }
                }
                else
                {
                    // If no GameObjects were found, break the loop
                    break;
                }
            }
        }


        pleasework();

    }

    void pleasework()
    {
        for (int i = 0; i < sfxSource.Length; i++)
        {
            if (sfxSource[i] != null)
            {
                sfxSource[i].volume = sfxVolume.value;
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
