
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator animator;

    private int levelToLoad;

    // Update is called once per frame
    void Update()
    {
       
    }

    public void FadeToLevel(int levelIndex)
    {
        animator.SetTrigger("StartFade");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
