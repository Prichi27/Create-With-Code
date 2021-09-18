using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;

    public float spawnRate;

    private float _timer;

    private void Start()
    {
        _timer = spawnRate;
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && _timer >= spawnRate)
        {
            _timer = 0;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
