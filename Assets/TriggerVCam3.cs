using UnityEngine;
using Cinemachine;

public class TriggerVCam3 : MonoBehaviour
{
    public GameObject objectA; // Reference to Object A
    public GameObject objectB; // Reference to Object B
    public CinemachineVirtualCamera vcam3; // Reference to the VCam3

    public float triggerDistance = 5f; // Distance at which the VCam3 should activate

    private bool vcamActivated = false;

    void Update()
    {
        // Check if all references are not null
        if (objectA != null && objectB != null && vcam3 != null)
        {
            // Calculate the distance between Object A and Object B
            float distance = Vector3.Distance(objectA.transform.position, objectB.transform.position);

            // Check if Object A is close enough to Object B and VCam3 is not activated yet
            if (distance <= triggerDistance && !vcamActivated)
            {
                // Activate VCam3
                vcam3.Priority = 10;
                vcamActivated = true;
            }
            // Check if Object A is far from Object B and VCam3 is activated
            else if (distance > triggerDistance && vcamActivated)
            {
                // Deactivate VCam3
                vcam3.Priority = 0;
                vcamActivated = false;
            }
        }
    }
}
