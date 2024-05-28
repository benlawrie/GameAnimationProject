using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseBenet : MonoBehaviour
{
    public Transform objectToFollow; // Object B
    public float distance = 5f; // Desired distance between objects
    public float movementSpeed = 5f; // Speed of movement
    public Animator animator; // Animator component for rolling animation
    private Vector3 offset; // Offset vector to maintain distance

    void Start()
    {
        // Calculate initial offset
        offset = transform.position - objectToFollow.position;

        // Ensure animator component is not null
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Calculate the target position with the desired distance offset
        Vector3 targetPosition = objectToFollow.position + offset;

        // Ensure the same distance is maintained
        Vector3 desiredPosition = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        
        transform.position = desiredPosition;

        // Calculate movement direction
        Vector3 movementDirection = transform.position - targetPosition;

        // Trigger rolling animation if movement direction is not zero
        animator.SetBool("IsRolling", movementDirection != Vector3.zero);
    }
}
