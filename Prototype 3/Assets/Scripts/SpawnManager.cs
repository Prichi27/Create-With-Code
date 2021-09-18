using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject _obstacle;

    private Vector3 _spawnPos = new Vector3(25, 0, 0);

    private float startDelay = 2;
    private float repeatRate = 2;

    PlayerController _playerController;
    private void Awake()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }


    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacles), startDelay, repeatRate);
    }

    private void SpawnObstacles()
    {
        if (_playerController.gameOver) return;
        Instantiate(_obstacle, _spawnPos, _obstacle.transform.rotation);
    }
}
