using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    [Tooltip("gravity")]
    [SerializeField]
    float gravity;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(gravity * Time.deltaTime * Vector3.down);
    }
}
