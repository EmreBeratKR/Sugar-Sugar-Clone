using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Collector[] collectors;


    public void CheckWin()
    {
        bool isWin = true;
        foreach (Collector col in collectors)
        {
            if (col.value != 0)
            {
                isWin = false;
                break;
            }
        }
        if (isWin)
        {
            StartCoroutine(NextLevel());
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3f);
        sceneController.NextLevel();
    }
}
