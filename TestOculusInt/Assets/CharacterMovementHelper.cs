using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;


public class CharacterMovementHelper : MonoBehaviour
{

    private XROrigin XRRig;
    private CharacterController characterController;
    private CharacterControllerDriver driver;

    // Start is called before the first frame update
    void Start()
    {
        XRRig = GetComponent<XROrigin>();
        characterController = GetComponent<CharacterController>();
        driver = GetComponent<CharacterControllerDriver>();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateCharacterController();
        
    }

    protected virtual void UpdateCharacterController()
    {
        if (XRRig == null || characterController == null)
            return;

        var height = Mathf.Clamp(XRRig.CameraInOriginSpaceHeight, driver.minHeight, driver.maxHeight);

        Vector3 center = XRRig.CameraInOriginSpacePos;
        center.y = height / 2f + characterController.skinWidth;

        characterController.height = height;
        characterController.center = center;
        
    }
}
