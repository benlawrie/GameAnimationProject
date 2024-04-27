using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benetController : MonoBehaviour
{
    Animator anim;

    public float translationSpeed = 0.005f;

    public GameObject target;

    public float IK_weight = 1.0f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (anim.GetBool("stop")){
        //     transform.Translate(0, 0, 0);
        // }
        // else{
        //     transform.Translate(0, 0, translationSpeed);
        // }
    }

    private void OnAnimatorIK(int layerIndex){
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position); 
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight);  

    } 
        
}

