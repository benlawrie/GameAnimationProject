using UnityEngine;
using Cinemachine;

public class BenetController2 : MonoBehaviour
{
    Animator anim;
    public GameObject torch;
    public GameObject leftHand; // This hand will hold the torch
    public GameObject rightHand; // This hand will pick up the sword
    public GameObject sword; // The sword to be picked up
    public GameObject target;
    public GameObject Benet;
    public GameObject trigger;
    public float IK_weight = 1.0f;
    public bool move = true;

    // Walking
    public float translationSpeed = 0.005f;
    public float runSpeed = 0.5f;
    public float rotationSpeed = 0.5f;

    // Cinemachine virtual cameras
    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    // Sword interaction
    private bool isNearSword = false;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        torch.transform.parent = leftHand.transform;
    }

    void Update()
    {
        if (anim.GetBool("test") == true)
        {
            move = false;
        }

        if (move == true)
        {
            HandleMovement();
            HandleCameraSwitching();
        }

        if (isNearSword && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed. Attempting to pick up the sword.");
            PickUpSword();
        }
    }

    private void HandleMovement()
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
    }

    private void HandleCameraSwitching()
    {
        // Check for look back input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            anim.SetBool("isLookingBack", true);
            SwitchToVcam2();
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("isLookingBack", false);
            SwitchToVcam1();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Debug.Log("Near the sword");
            isNearSword = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            Debug.Log("Left the sword area");
            isNearSword = false;
        }
    }

    private void PickUpSword()
    {
        if (sword != null)
        {
            Debug.Log("Attaching the sword to the right hand");

            // Attach the sword to the player's right hand position
            sword.transform.SetParent(rightHand.transform);

            // Adjust the sword's position and rotation to the specified values
            sword.transform.localPosition = new Vector3(-0.1f, 0.1f, 0f);
            sword.transform.localRotation = Quaternion.Euler(0f, 90f, 90f);

            sword.GetComponent<Rigidbody>().isKinematic = true; // Disable physics on the sword

            // Debug logs to track the sword's position and rotation
            Debug.Log("Sword local position after attaching: " + sword.transform.localPosition);
            Debug.Log("Sword local rotation after attaching: " + sword.transform.localRotation);
        }
        else
        {
            Debug.Log("Sword object is null. Cannot pick up.");
        }
    }

    private void OnAnimatorIK(int layerIndex)
    {
        anim.SetIKPosition(AvatarIKGoal.RightHand, target.transform.position);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, IK_weight);
    }

    private void SwitchToVcam2()
    {
        if (vcam2 != null && vcam1 != null)
        {
            // Set vcam2 priority higher to switch to it
            vcam2.Priority = 10;
            vcam1.Priority = 5;
        }
    }

    private void SwitchToVcam1()
    {
        if (vcam2 != null && vcam1 != null)
        {
            // Set vcam1 priority higher to switch back to it
            vcam1.Priority = 10;
            vcam2.Priority = 5;
        }
    }
}
