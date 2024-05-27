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

    //Walking
    public float translationSpeed = 0.005f;
    public float rotationSpeed = 0.5f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        torch.transform.parent = hand.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetBool("test") == true){
            move = false;
        }
        
        if(move == true){
            float translation = Input.GetAxis("Vertical") * translationSpeed;
            //translation += Time.deltaTime;
            transform.Translate(0, 0, translation);

            float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
            rotation += Time.deltaTime;
            transform.Rotate(0, rotation, 0);

            if(translation != 0){
                anim.SetBool("isWalking", true);
                if (translation < 0){
                    anim.SetFloat("charSpeed", -1.0f);
                }
                else{
                    anim.SetFloat("charSpeed", 1.0f);
                }
            }
            else{
                anim.SetBool("isWalking", false);
            }
        }

    }

    private void OnAnimatorIK(int layerIndex){
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position); 
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight); 
        
    } 

}
