using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Lever : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform leverTop;
    public float maxAngle = 45f;
    public float angleThreshold = 10f;
    private float currentAngle = 0f;
    private HingeJoint hingeJoint;
    private bool soundPlayed = false;
    private XRController xrController;

    void Start()
    {
        xrController = GetComponent<XRController>();
    }

    void Update()
    {
        if (xrController != null && xrController.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float input))
        {
            // Calculate the new angle based on input
            currentAngle += input * maxAngle * Time.deltaTime;

            // Clamp the angle to stay within limits
            currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);

            // Set the rotation of the lever top
            leverTop.localRotation = Quaternion.Euler(0, 0, currentAngle);

            // Check if the angle exceeds the threshold to play sound
            if (Mathf.Abs(currentAngle) > angleThreshold && !audioSource.isPlaying)
            {
                audioSource.Play();
                soundPlayed = true;
            }

            // Reset the sound if the angle is below the threshold
            if (Mathf.Abs(currentAngle) < angleThreshold && soundPlayed)
            {
                soundPlayed = false;
                audioSource.Stop();
            }
        }
    }
}