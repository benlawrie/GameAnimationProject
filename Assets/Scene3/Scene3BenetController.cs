using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenetController2 : MonoBehaviour
{
    private Animator anim;
    public GameObject torch;
    public GameObject hand;
    public GameObject target;

    public float IK_weight = 1.0f;

    //Walking
    public float translationSpeed = 3.0f; // Increased speed for better visibility
    public float rotationSpeed = 100.0f; // Increased rotation speed

    void Start()
    {
        anim = GetComponent<Animator>();
        if (hand != null && torch != null)
        {
            torch.transform.SetParent(hand.transform);
        }
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleAnimations();
    }

    void HandleMovement()
    {
        float translation = Input.GetAxis("Vertical") * translationSpeed * Time.deltaTime;
        transform.Translate(0, 0, translation);
    }

    void HandleRotation()
    {
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);
    }

    void HandleAnimations()
    {
        bool isWalking = Mathf.Abs(Input.GetAxis("Vertical")) > 0;
        anim.SetBool("isWalking", isWalking);
        anim.SetFloat("charSpeed", Input.GetAxis("Vertical"));
    }

    void OnAnimatorIK(int layerIndex)
    {
        if (target != null)
        {
            anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position); 
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight); 
        }
    }
}
