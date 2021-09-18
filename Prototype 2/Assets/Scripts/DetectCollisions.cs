using Prototype;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Const.ANIMAL_TAG))
        {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
