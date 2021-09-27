using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public int enemyCount; 
    public int waveNumber = 1;

    [SerializeField] float _spawnRange;
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] GameObject _powerupPrefab;

    private void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;

        if (enemyCount == 0) 
        {
            SpawnPowerup();
            SpawnEnemyWave(++waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(_enemyPrefab, GenerateSpawnPoint(), _enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        Instantiate(_powerupPrefab, GenerateSpawnPoint(), _powerupPrefab.transform.rotation);
    }

    Vector3 GenerateSpawnPoint()
    {
        var spawnPosX = Random.Range(-_spawnRange, _spawnRange);
        var spawnPosZ = Random.Range(-_spawnRange, _spawnRange);

        return new Vector3(spawnPosX, 0, spawnPosZ);
    }
}
