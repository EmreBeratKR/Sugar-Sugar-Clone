using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarSpawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject sugarPrefab;
    [SerializeField] private int sugarCount;
    [SerializeField] private float waitDuration;
    private float timer = 0f;


    private void FixedUpdate()
    {
        timer +=  Time.deltaTime;
        if (timer >= waitDuration)
        {
            Spawn();
            timer = 0f;
        }
    }

    private void Spawn()
    {
        Instantiate(sugarPrefab, transform.position + Vector3.right * Random.Range(-3f, 3f), Quaternion.identity, parent);
        sugarCount--;
        if (sugarCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
