using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyController : MonoBehaviour
{
    // Start is called before the first frame update
    public keyTrigger trigger;
    public keyTrigger trigger2;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger2.collided == true){
            anim.SetBool("unlock", true);
        }
    }
}
