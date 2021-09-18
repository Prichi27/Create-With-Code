using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Spawner Settings")]
    [Tooltip("Animal prefabs to spawn")]
    public GameObject[] animals;

    [Tooltip("The transform which will be the parent to the the prefab")]
    public Transform parent;
    
    [Tooltip("spawn position range")]
    public float spawnRangeX, spawnRangeZ;

    [Tooltip("Rate at which prefabs spawn")]
    public float spawnRate;
    
    private float _time;

    private void Start()
    {
        SpawnRandomAnimal();    
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= spawnRate)
        {
            _time = 0;
            SpawnRandomAnimal();
        }
    }

    private void SpawnRandomAnimal()
    {
        int index = Random.Range(0, animals.Length);

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnRangeZ);

        Instantiate(animals[index], spawnPosition, animals[index].transform.rotation, parent);
    }
}
