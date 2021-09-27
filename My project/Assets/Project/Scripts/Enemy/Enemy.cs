using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour, IMovable
{
    [SerializeField] float _speed;
    [SerializeField] float _stoppingDistance;
    private GameObject _player;
    private Rigidbody _rb;
    private NavMeshAgent _enemy;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        _enemy = GetComponent<NavMeshAgent>();
        _enemy.speed = _speed;
        _enemy.stoppingDistance = _stoppingDistance;
    }

    public void Move()
    {
        _enemy.SetDestination(_player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
}
