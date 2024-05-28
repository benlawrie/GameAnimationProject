using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyTrigger : MonoBehaviour
{
// Start is called before the first frame update
    public GameObject trigger;
    public Vector3 startingPos;
    public Quaternion startingRot;
    public bool collided;
    public Animator anim;
    

    void Start()
    {
        collided = false;
        startingPos = trigger.transform.position;
        startingRot = trigger.transform.rotation;
        //anim = GetComponent<Animator>();
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
}
