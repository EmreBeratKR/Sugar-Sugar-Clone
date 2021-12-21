using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void QuitLevel()
    {
        SceneManager.LoadScene(0);
    }
    
    public void LoadLevelSelection()
    {
        SceneManager.LoadScene(1);
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(int level)
    {
        SceneManager.LoadScene(level+1);
    }
}
