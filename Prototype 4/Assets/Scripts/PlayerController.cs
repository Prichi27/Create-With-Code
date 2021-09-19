using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasPower = false;

    [SerializeField] private float _speed, _pushStrength;
    [SerializeField] private GameObject _focalPoint, _powerIndicator;

    private Rigidbody _rb;

    private void Start()
    {
        _rb =  GetComponent<Rigidbody>();
    }

    private void Update()
    {
        var verticalInput = Input.GetAxis("Vertical");

        _rb.AddForce(verticalInput * _speed * Time.deltaTime * _focalPoint.transform.forward);
        _powerIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            if (enemyRigidBody == null) return;

            Vector3 pushDirection = collision.transform.position - transform.position;
            enemyRigidBody.AddForce(_pushStrength * pushDirection.normalized, ForceMode.Impulse);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPower = true;
            _powerIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdownRoutine());
        }
    }

    IEnumerator PowerUpCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPower = false;
        _powerIndicator.SetActive(false);
    }
}
