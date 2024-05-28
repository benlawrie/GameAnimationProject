using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BenetController2 : MonoBehaviour
{
    Animator anim;
    public GameObject torch;
    public GameObject hand;
    public GameObject target;
    public GameObject Benet;
    public GameObject trigger;
    public float IK_weight = 1.0f;
    public bool move = true;

    // Walking
    public float translationSpeed = 0.005f;
    public float runSpeed = 0.5f;
    public float rotationSpeed = 0.5f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        torch.transform.parent = hand.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("test") == true)
        {
            move = false;
        }

        if (move == true)
        {
            bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
            anim.SetBool("isRunning", isRunning);

            float speed = isRunning ? runSpeed : translationSpeed;

            float translation = Input.GetAxis("Vertical") * speed;
            transform.Translate(0, 0, translation);

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            transform.Rotate(0, rotation, 0);

            if (translation != 0)
            {
                anim.SetBool("isWalking", true);
                anim.SetFloat("charSpeed", translation < 0 ? -1.0f : 1.0f);
            }
            else
            {
                anim.SetBool("isWalking", false);
            }

            // Check for look back input
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetBool("isLookingBack", true);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                anim.SetBool("isLookingBack", false);
            }
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position); 
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight); 
    }
}
