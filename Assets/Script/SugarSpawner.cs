using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarSpawner : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject sugarPrefab;
    [SerializeField] private int sugarCount;
    private  float sleepDuration = 2f;
    [SerializeField] private float waitDuration = 0.1f;
    private float timer = 0f;
    private float startTime;


    private void Start()
    {
        startTime = Time.time;
    }

    private void FixedUpdate()
    {
        if ((Time.time - startTime) >= sleepDuration)
        {
            timer +=  Time.deltaTime;
            if (timer >= waitDuration)
            {
                Spawn();
                timer = 0f;
            }
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
