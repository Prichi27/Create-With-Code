using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    [Tooltip("Projectile's speed")]
    public float speed;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.forward);
    }
}
