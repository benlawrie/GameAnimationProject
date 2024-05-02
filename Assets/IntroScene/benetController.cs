using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class benetController : MonoBehaviour
{
    Animator anim;

    public float translationSpeed = 0.005f;
    public GameObject torch;
    public GameObject hand;
    public GameObject target;
    public GameObject note;
    public GameObject Benet;
    public float IK_weight = 1.0f;

    private bool callNote = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        torch.transform.parent = hand.transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnAnimatorIK(int layerIndex){
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position); 
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight); 
        if (Time.time > 12){
            anim.SetLookAtPosition(note.transform.position);
            anim.SetLookAtWeight(1f);
        } 
        
    } 
        
}

