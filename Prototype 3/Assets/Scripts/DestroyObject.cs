using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnBecameVisible()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
