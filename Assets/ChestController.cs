using UnityEngine;

public class ChestController : MonoBehaviour
{
    public Animator chestAnimator; // Reference to the Animator component of the chest
    public string openAnimationName = "Open"; // The name of the open animation state
    private bool isPlayerNear = false; // Flag to track if the player is near the chest

    // Start is called before the first frame update
    void Start()
    {
        if (chestAnimator == null)
        {
            Debug.LogError("Chest Animator is not assigned.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is near and the E key is pressed
        if (isPlayerNear && Input.GetKeyDown(KeyCode.E))
        {
            PlayOpenAnimation();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is near the chest.");
            isPlayerNear = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the object that exited the trigger is the player
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left the chest area.");
            isPlayerNear = false;
        }
    }

    private void PlayOpenAnimation()
    {
        // Play the open animation
        if (chestAnimator != null)
        {
            chestAnimator.Play(openAnimationName);
        }
    }
}