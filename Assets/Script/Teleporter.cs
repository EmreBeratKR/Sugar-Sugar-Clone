using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform output;
    private float sign;


    private void Start()
    {
        sign = transform.localScale.y > 0f ? 1f : -1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Vector3 offset = other.transform.position - transform.position;
        other.transform.position = output.position + new Vector3(offset.x, other.transform.localScale.y * sign);
    }
}
