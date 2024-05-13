using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4BenetController : MonoBehaviour
{
    Animator anim;
    public GameObject torch;
    public GameObject hand;
    public GameObject target;
    public GameObject Benet;
    public float IK_weight = 1.0f;
    // Start is called before the first frame update
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
        
    } 
}
