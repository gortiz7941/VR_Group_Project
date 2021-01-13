﻿using System.Collections;
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
        RotateOnPrimaryButtonPress();
    }

    //*******************************************************
    // Rotates a pipe 90 degrees if the player presses a primary button.
    // ******************************************************
    private void RotateOnPrimaryButtonPress() {
        isHit = ray.GetCurrentRaycastHit(out hit);

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && isHit && hit.transform.gameObject == gameObject) {
            if (pipeConnectedTo != null) {
                XRSocketInteractor rotateSocket = hit.transform.GetComponent<PipeElbow>().pipeConnectedTo.GetComponentInChildren<XRSocketInteractor>();
                if (previousPress != buttonValue) {
                    previousPress = buttonValue;

                    if (buttonValue == true) {
                        rotateSocket.attachTransform.localRotation *= Quaternion.Euler(new Vector3(0, 0, 90));
                    }
                }
            }
        }
    }
}
