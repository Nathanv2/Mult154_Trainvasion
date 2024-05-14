using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource buttonAudio;
    public AudioSource backgroundAudio;

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

    public void PlayButtonAudio()
    {
        buttonAudio.Stop();
    }

}
