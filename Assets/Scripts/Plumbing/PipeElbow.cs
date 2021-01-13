using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeElbow : Pipe {
    XRController controller;
    XRRayInteractor ray;
    RaycastHit hit;
    bool isHit = false;
    bool previousPress = false;
    
    protected override void Start()
    {
        base.Start();
        controller = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        ray = controller.GetComponent<XRRayInteractor>();
    }

    protected override void Update() {
        base.Update();
        AllowRotation();
    }

    //*******************************************************
    // Rotates a pipe if the player presses a primary button.
    // ******************************************************
    private void AllowRotation() {
        isHit = ray.GetCurrentRaycastHit(out hit);

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && isHit && hit.transform.tag == "Elbow") {
            if (pipeConnectedTo != null) {
                print(hit.transform.name);
                print(hit.transform.GetComponentInChildren<PipeElbow>().name);
                print(hit.transform.GetComponentInChildren<PipeElbow>().pipeConnectedTo.name);
                XRSocketInteractor rotateSocket = hit.transform.GetComponentInChildren<PipeElbow>().pipeConnectedTo.GetComponent<XRSocketInteractor>();
                if (previousPress != buttonValue) {
                    previousPress = buttonValue;

                    if (buttonValue == true) {
                        RotateElbow(rotateSocket.attachTransform);
                    }
                }
            }
        }
    }

    //*******************************************************
    // Rotates a piece 90 degrees around the X axis.
    // ******************************************************
    private void RotateElbow(Transform attachTransform) {
        attachTransform.localRotation *= Quaternion.Slerp(attachTransform.localRotation, Quaternion.LookRotation(new Vector3(-90, 0, 0)), 1.0f);
    }
}
