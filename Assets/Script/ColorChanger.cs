using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Color color;
    [SerializeField] private SpriteRenderer[] renderers;


    private void OnEnable()
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.color = color;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<SpriteRenderer>().color = color;
    }
}
