using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Crate : MonoBehaviour
{
    public XRGrabInteractable grabInteractable;
    public Transform grabPoint1;
    public Transform grabPoint2;

    private bool isGrabbed = false;

    private void Start()
    {
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Check if both grab points are being used
        if (interactor.transform == grabPoint1 || interactor.transform == grabPoint2)
        {
            isGrabbed = true;
        }
        
        // Disable the default movement to control it manually
        grabInteractable.movementType = XRGrabInteractable.MovementType.Kinematic;
    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        isGrabbed = false;
    }

    private void Update()
    {
        if (isGrabbed)
        {
            MoveCrate();
        }
    }

    private void MoveCrate()
    {
        // Calculate the midpoint of the grab points
        Vector3 midpoint = (grabPoint1.position + grabPoint2.position) / 2;
        Vector3 newPosition = new Vector3(midpoint.x, transform.position.y, midpoint.z);

        // Move the crate to the new position
        transform.position = newPosition;
    }
}