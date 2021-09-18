using Prototype;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        if (gameObject.CompareTag(Const.ANIMAL_TAG)) Debug.LogWarning("Perdi frere!");
        Destroy(gameObject);
    }
}
