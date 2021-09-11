using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject projectilePrefab;
    private float _horizontalInput;

    private float xMin, xMax;

    private void Start()
    {
        var camera = Camera.main;

        xMin = camera.ViewportToWorldPoint(new Vector3(0,0,camera.transform.position.y)).x;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, camera.transform.position.y)).x;
    }

    // Update is called once per frame
    void Update()
    {
        KeepPlayerInBound();
        GetUserInput();

        transform.Translate(_horizontalInput * speed * Time.deltaTime * Vector3.right);
    }

    private void GetUserInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // lauch prefab 
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    private void SetPlayerXPosition(float x)
    {
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }

    private void KeepPlayerInBound()
    {
        if (transform.position.x < xMin)
        {
            SetPlayerXPosition(xMin);
        }

        if (transform.position.x > xMax)
        {
            SetPlayerXPosition(xMax);
        }
    }
}
