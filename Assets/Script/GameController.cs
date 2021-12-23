using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private SceneController sceneController;
    [SerializeField] private Collector[] collectors;
    [SerializeField] private DoubleCollector[] doubleCollectors;


    public void CheckWin()
    {
        bool isWin = true;
        if (collectors != null)
        {
            foreach (Collector col in collectors)
            {
                if (col.value != 0)
                {
                    isWin = false;
                    break;
                }
            }
        }
        if (isWin && doubleCollectors != null)
        {
            foreach (DoubleCollector col in doubleCollectors)
            {
                if (col.value != 0)
                {
                    isWin = false;
                    break;
                }
            }
        }
        if (isWin)
        {
            AudioController.Play_LevelCompletion();
            sceneController.NextLevel();
        }
    }
}
