using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [Tooltip("Gets the players reference")]
    public GameObject Player;

    [Tooltip("How far the camera is to the player")]
    public Vector3 Offset;

    private void LateUpdate()
    {
        if (Player == null) return;

        // Follows the player
        transform.position = Player.transform.position + Offset;
    }
}
