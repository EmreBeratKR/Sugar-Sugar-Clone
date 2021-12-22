using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Collector : MonoBehaviour
{
    private GameController gameController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TextMesh textMesh;
    public int value;

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
        if (value > 0 && other.GetComponent<SpriteRenderer>().color == spriteRenderer.color)
        {
            UpdateText(-1);
            Destroy(other.gameObject);
            gameController.CheckWin();
        }
    }

    private void UpdateText(int delta = 0)
    {
        value += delta;
        textMesh.text = value.ToString();
    }
}
