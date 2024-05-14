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

        if (sfxSource[0] == null)
        {
            // Find GameObjects with AudioSource component
            GameObject[] sfxObjects = GameObject.FindGameObjectsWithTag("Hero");

            // Assign AudioSource to sfxSource[2] if found
            if (sfxObjects.Length > 0)
            {
                AudioSource audioSource = sfxObjects[0].GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    sfxSource[0] = audioSource;
                }
            }
        }
    }
    void UpdateVolumes()
    {

        float masterValue = masterVolume.value;


        for (int i = 0; i < musicSource.Length; i++)
        {
            musicSource[i].volume = masterValue;
        }


        for (int i = 0; i < sfxSource.Length; i++)
        {
            sfxSource[i].volume = masterValue;
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
