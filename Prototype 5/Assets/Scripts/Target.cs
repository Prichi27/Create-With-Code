using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int pointValue;

    public ParticleSystem explosionEffect;

    private Rigidbody _rb;
    private GameManager _manager;

    private float minForce = 12;
    private float maxForce = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _manager = GameObject.FindObjectOfType<GameManager>();

        _rb.AddForce(RandomForce(), ForceMode.Impulse);
        _rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }

    private float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    private Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }

    public void DestroyObject()
    {
        if (!_manager.isGameActive) return;
        Instantiate(explosionEffect, transform.position, explosionEffect.transform.rotation);
        _manager.UpdateScore(pointValue);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!gameObject.CompareTag("Bad"))
            _manager.UpdateLives();

        Destroy(gameObject);
    }
}
