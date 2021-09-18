using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    PlayerController _playerController;

    private float _leftBound = -15;

    private void Awake()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerController == null || _playerController.gameOver) return;
        transform.Translate(_moveSpeed * Time.deltaTime * Vector3.left);

        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle")) Destroy(gameObject);
    }
}
