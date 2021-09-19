using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] float _spawnRange;
    [SerializeField] GameObject _enemyPrefab;

    private void Start()
    {
        Instantiate(_enemyPrefab, GenerateSpawnPoint(), _enemyPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPoint()
    {
        var spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        var spawnPosZ = Random.Range(-_spawnRange, _spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
