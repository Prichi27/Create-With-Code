using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed;

    private GameObject _player;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 lookAt = _player.transform.position - transform.position;
        _rb.AddForce(_speed * Time.deltaTime * lookAt.normalized);

        if (transform.position.y < -10) Destroy(gameObject);
    }


}
