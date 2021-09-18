using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Droplet : MonoBehaviour
{
    public MeshRenderer Renderer;

    // Cube settings
    [Header("Cube Settings")]
    [Tooltip("Min scale of cube")]
    [SerializeField]
    float minScale;

    [Tooltip("Max scale of cube")]
    [SerializeField]
    float maxScale;

    [Tooltip("Color of cube")]
    [SerializeField]
    Color materialColor;

    [Tooltip("Min rotation speed of cube")]
    [SerializeField]
    float minRotationSpeed;

    [Tooltip("Max rotation speed of cube")]
    [SerializeField]
    float maxRotationSpeed;

    void Start()
    {
        var scale = Random.Range(minScale, maxScale);
        
        transform.localScale = Vector3.one * scale;
        
        Material material = Renderer.material;
        
        material.color = materialColor;
    }
    
    void Update()
    {
        var rotationSpeed = Random.Range(minRotationSpeed, maxRotationSpeed);

        var rotationY = Random.Range(0, 2);
        var rotationZ = Random.Range(0, 2);

        var rotation = rotationSpeed * Time.deltaTime * new Vector3(1, rotationY, rotationZ);
        transform.Rotate(rotation);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
