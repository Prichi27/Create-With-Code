using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public GameObject rain;
    public Transform[] spawnLocation;
    public float spawnRate;

    private float _timer;

    private void Awake()
    {
        _timer = spawnRate;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= spawnRate)
        {
            var index = Random.Range(0, spawnLocation.Length);
            Instantiate(rain, spawnLocation[index].position, Quaternion.identity);
            _timer = 0;
        }
    }
}
