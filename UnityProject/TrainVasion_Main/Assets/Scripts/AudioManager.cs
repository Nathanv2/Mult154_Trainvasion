using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource buttonAudio;
    public AudioSource mainMenuAudio;
    public AudioSource trainvasionAudioComponent;
    public AudioSource explorationAudioComponent;
    public AudioSource aliencolliderAudioComponent;
    public GameObject trainvasionAudio;
    public GameObject explorationAudio;
    public GameObject aliencolliderAudio;

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

    public void Update()
    {
        trainvasionAudio = GameObject.Find("MainBackground");
        explorationAudio = GameObject.Find("ExplorationBackground");
        aliencolliderAudio = GameObject.Find("AlienCollision");
        if (trainvasionAudioComponent == null)
        {
            trainvasionAudioComponent = trainvasionAudio.GetComponent<AudioSource>();
        }

        if (explorationAudioComponent == null)
        {
            explorationAudioComponent = explorationAudio.GetComponent<AudioSource>();
        }

        if (aliencolliderAudioComponent == null)
        {
            aliencolliderAudioComponent = aliencolliderAudio.GetComponent<AudioSource>();
        }
    }

    public void MainMenuAudio()
    {
        mainMenuAudio.Stop();
    }

}
