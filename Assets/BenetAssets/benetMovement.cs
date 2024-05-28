using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benetMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed at which the player moves

    void Update()
    {
        // Get input from WASD keys
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical"); // W/S or Up/Down arrow keys

        // Calculate the new position
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        transform.Translate(move * moveSpeed * Time.deltaTime);
    }
}
