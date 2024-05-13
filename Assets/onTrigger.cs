using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trigger;
    public Vector3 startingPos;
    public Quaternion startingRot;
    public Animator anim;
    public bool collided;
    

    void Start()
    {
        collided = false;
        startingPos = trigger.transform.position;
        startingRot = trigger.transform.rotation;
        anim = GetComponentInParent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        trigger.transform.position = startingPos;
        trigger.transform.rotation = startingRot;
    }

    void OnTriggerEnter(Collider other){
        Debug.Log("Colided");
        //anim.SetBool("test", true);
        //StartCoroutine(MyCoroutine());
        collided = true;
    }

    void OnTriggerExit(Collider other){
        collided = false;
    //     Debug.Log("Exit");
    //     anim.SetBool("test", false);
    //     //anim.SetBool("isWalking", true);
    }

    IEnumerator MyCoroutine(){
        yield return new WaitForSeconds(10);
        Destroy(trigger);
        anim.SetBool("isWalking", false);
        anim.SetBool("test", false);

    }
}
