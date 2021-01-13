using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class EnableChildSocketIfSnapped : MonoBehaviour {
    /*
    private XRController controller;
    private XRRayInteractor ray;
    private RaycastHit hit;
    private bool isHit = false;
    private bool previousPress = false;


    private bool isConnectedToSource = false;
    */

    private XRSocketInteractor socket;
    private XRSocketInteractor childSocket;


    // Start is called before the first frame update
    void Start()
    {
        //controller = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        //ray = controller.GetComponent<XRRayInteractor>();
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        EnableSnap();
        //MarkChildAsConnected();
        //AllowElbowRotation();
    }

    private void EnableSnap() {
        if (socket.selectTarget) {
            if (childSocket = socket.selectTarget.GetComponentInChildren<XRSocketInteractor>()) {
                childSocket.socketActive = true;
                //childSocket.isConnectedToSource = true;
            }
        } else {
            if (childSocket != null) {
                childSocket.socketActive = false;
                childSocket = null;
            }
        }
    }

    /*
    private void AllowElbowRotation() {        
        isHit = ray.GetCurrentRaycastHit(out hit);

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && isHit && hit.transform.tag == "Elbow") {
            if (buttonValue && previousPress != buttonValue) {
                RotateElbow(socket.attachTransform);
            }
            previousPress = buttonValue;
        }
    }

    private void RotateElbow(Transform transform) {
        transform.localRotation *= Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(new Vector3(-90, 0, 0)), 1.0f);
    }

    private void MarkChildAsConnected() {
        if (isConnectedToSource) {
            isConnectedToSource = true;
        }
    }
    */
}