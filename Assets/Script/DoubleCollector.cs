using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DoubleCollector : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private SpriteRenderer[] spriteRenderers;
    [SerializeField] private TextMesh textMesh;
    [SerializeField] private int firstValue;
    [SerializeField] private int secondValue;
    public int value 
    {
        get
        {
            return firstValue + secondValue;
        }
    }

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        textMesh.text = value.ToString();
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (value > 0)
        {
            if (firstValue > 0 && other.GetComponent<SpriteRenderer>().color == spriteRenderers[0].color)
            {
                firstValue--;
                UpdateText();
                Destroy(other.gameObject);
                gameController.CheckWin();  
            }
            else if (secondValue > 0 && other.GetComponent<SpriteRenderer>().color == spriteRenderers[1].color)
            {
                secondValue--;
                UpdateText();
                Destroy(other.gameObject);
                gameController.CheckWin();   
            }
        }
    }

    private void UpdateText()
    {
        textMesh.text = value.ToString();
    }
}
