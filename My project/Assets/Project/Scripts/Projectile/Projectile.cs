using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour, IMovable
{
    [SerializeField] float speed;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        Move();
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    public void Move()
    {
        _rb.AddForce(transform.forward * speed, ForceMode.Impulse);
    }
}
