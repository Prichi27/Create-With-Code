using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Vehichle's speed")]
    [SerializeField]
    private float Speed;

    [Tooltip("Vehichle's rpm")]
    [SerializeField]
    private float RPM;

    [Tooltip("Vehichle's horsepower")]
    [SerializeField]
    private float _horsePower;

    [Tooltip("Vehicle's turn speed")]
    [SerializeField]
    private float TurnSpeed;

    [Tooltip("Vehicle's center of mass")]
    [SerializeField]
    private Transform _centerOfMass;

    [Tooltip("Vehicle's wheels")]
    [SerializeField]
    private List<WheelCollider> _wheelColliders;

    [Tooltip("Vehicle's Speedometer text")]
    [SerializeField]
    private TextMeshProUGUI _speedometerText;

    [Tooltip("Vehicle's Speedometer text")]
    [SerializeField]
    private TextMeshProUGUI _rpmText;

    private Rigidbody _rb;
    
    private float vertical;
    private float horizontal;

    private int _wheelsOnGround;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.centerOfMass = _centerOfMass.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Gets player input
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

    }

    private void FixedUpdate()
    {
        if (!IsOnGround()) return;

        _rb.AddForce(_horsePower * vertical * transform.forward);
        transform.Rotate(Vector3.up, horizontal * TurnSpeed * Time.deltaTime);

        Speed = _rb.velocity.magnitude * 3.6f; //3.6 for km/h
        _speedometerText.text = $"Speed: {Mathf.RoundToInt(Speed)}Km/h"; //3.6 for km/h

        RPM = (Speed % 30) * 40;
        _rpmText.text = $"RPM: {Mathf.RoundToInt(RPM)}";
    }

    bool IsOnGround()
    {
        _wheelsOnGround = 0;

        foreach (WheelCollider wheel in _wheelColliders)
        {
            if (wheel.isGrounded) _wheelsOnGround++;
        }

        return _wheelsOnGround > 0;
    }
}
