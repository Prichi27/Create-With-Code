using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Vehichle's speed")]
    public float Speed; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        // Move the vehicle forward
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
