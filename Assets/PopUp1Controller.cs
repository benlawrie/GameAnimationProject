using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUp1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public onTrigger trigger;
    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger.collided == true){
            anim.SetBool("Pop1Trigger", true);
        }
        if(trigger.collided == false){
            anim.SetBool("Pop1Trigger", false);
        }
    }
}
