using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Vehichle's speed")]
    public float Speed;

    [Tooltip("Vehicle's turn speed")]
    public float TurnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Gets player input
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        // Move the vehicle forward
        transform.Translate(Speed * Time.deltaTime * vertical * Vector3.forward);
        transform.Rotate(Vector3.up, horizontal * TurnSpeed * Time.deltaTime);
    }
}
