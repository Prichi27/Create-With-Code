using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePropeller : MonoBehaviour
{
    [Tooltip("Propeller rotation speed")]
    public float RotationSpeed; 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, RotationSpeed * Time.deltaTime);
    }
}
