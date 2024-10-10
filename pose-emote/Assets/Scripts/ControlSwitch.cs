using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControlSwitch : MonoBehaviour
{
    public GameObject rightController;
    public GameObject leftController;
    public GameObject leftStart;
    public GameObject rightStart;
    private GameObject curRightController;
    private GameObject curLeftController;

    public GameObject rFakeWave;
    public GameObject rFakeFacepalm;
    public GameObject lFakeWave;
    public GameObject lFakeFacepalm;

    // Cooldown duration
    private float switchCooldown = 0.5f;
    private float lastSwitchTimeRight = 0f;
    private float lastSwitchTimeLeft = 0f;

    void Start()
    {
        // Instantiate initial prefabs
        curRightController = Instantiate(rightStart, rightController.transform.position, rightController.transform.rotation);
        curLeftController = Instantiate(leftStart, leftController.transform.position, leftController.transform.rotation);
    }

    void Update()
    {
        // Check for button presses using the new input action names
        if (Time.time >= lastSwitchTimeRight + switchCooldown)
        {
            // Check for button presses using the new input action names
            if (Input.GetButtonDown("XRI_Right_PrimaryButton"))  // A button
            {
                ChangeRightControllerPrefab(rFakeWave);
                lastSwitchTimeRight = Time.time; // Update the last switch time
            }
            else if (Input.GetButtonDown("XRI_Right_SecondaryButton"))  // B button
            {
                ChangeRightControllerPrefab(rFakeFacepalm);
                lastSwitchTimeRight = Time.time; // Update the last switch time
            }
        }

        if (Time.time >= lastSwitchTimeLeft + switchCooldown)
        {
            if (Input.GetButtonDown("XRI_Left_PrimaryButton"))  // X button
            {
                ChangeLeftControllerPrefab(lFakeWave);
                lastSwitchTimeLeft = Time.time; // Update the last switch time
            }
            else if (Input.GetButtonDown("XRI_Left_SecondaryButton"))  // B button
            {
                ChangeLeftControllerPrefab(lFakeFacepalm);
                lastSwitchTimeLeft = Time.time; // Update the last switch time
            }
        }
    }

    private void ChangeRightControllerPrefab(GameObject newPrefab)
    {
        // Destroys current prefab and instantiates new one based on button pressed
        if (curRightController != null)
        {
            Destroy(curRightController);
        }
        // Instantiate without a parent but set position and rotation to match the right controller
        curRightController = Instantiate(newPrefab, rightController.transform.position, rightController.transform.rotation);
    }

    private void ChangeLeftControllerPrefab(GameObject newPrefab)
    {
        // Destroys current prefab and instantiates new one based on button pressed
        if (curLeftController != null)
        {
            Destroy(curLeftController);
        }
        // Instantiate without a parent but set position and rotation to match the left controller
        curLeftController = Instantiate(newPrefab, leftController.transform.position, leftController.transform.rotation);
    }
}
