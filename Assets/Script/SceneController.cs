using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private CanvasGroup transition;
    private float transitionDuration = 0.5f;


    private void Awake()
    {
        if (!Singleton.instance.isReseting)
        {
            StartCoroutine(TransitionOutCo());
        }
    }

    public void QuitLevel()
    {
        Singleton.instance.isReseting = false;
        SceneManager.LoadScene(0);
    }
    
    public void LoadLevelSelection()
    {
        Singleton.instance.isReseting = false;
        SceneManager.LoadScene(1);
    }

    public void ResetLevel()
    {
        Singleton.instance.isReseting = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Singleton.instance.isReseting = false;
        StartCoroutine(NextLevelCo());
    }

    private IEnumerator NextLevelCo()
    {
        yield return new WaitForSeconds(3f - transitionDuration);
        float timeElapsed = 0f;
        float fadeDuration = transitionDuration;
        while (true)
        {
            if (timeElapsed >= fadeDuration)
            {
                transition.alpha = 1f;
                break;
            }
            timeElapsed += Time.deltaTime;
            transition.alpha = timeElapsed / fadeDuration;
            yield return 0;
        }
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadScene(int level)
    {
        Singleton.instance.isReseting = false;
        SceneManager.LoadScene(level+1);
    }

    private IEnumerator TransitionOutCo()
    {
        transition.alpha = 1f;
        float timeLeft = transitionDuration;
        float fadeDuration = transitionDuration;
        while (true)
        {
            if (timeLeft <= 0f)
            {
                transition.alpha = 0f;
                break;
            }
            timeLeft -= Time.deltaTime;
            transition.alpha = timeLeft / fadeDuration;
            yield return 0;
        }
    }

    public void ToggleMusic()
    {
        AudioController.ToggleMusic();
    }
}
