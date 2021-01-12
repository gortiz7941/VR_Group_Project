using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class PipeSocket : XRSocketInteractor {
    private XRController controller;
    private XRRayInteractor ray;
    private RaycastHit hit;
    private bool isHit = false;
    private bool previousPress = false;

    private XRSocketInteractor socket;
    private XRSocketInteractor childSocket;

    private bool isConnectedToSource = false;

    // Start is called before the first frame update
    protected override void Start() {
        base.Start();
        controller = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        ray = controller.GetComponent<XRRayInteractor>();
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    protected void Update() {
        MarkChildAsConnected();
        EnableSnap();
        AllowRotation();
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

    private void AllowRotation() {
        isHit = ray.GetCurrentRaycastHit(out hit);

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && isHit && hit.transform.tag == "Elbow") {
            XRSocketInteractor rotateSocket = socket;
            if (buttonValue && previousPress != buttonValue) {
                RotateElbow(rotateSocket);
            }
            previousPress = buttonValue;
        }
    }

    private void RotateElbow(XRSocketInteractor rotateSocket) {
        //print("RotateElbow called");
        //print("attachTransform name:" + socket.attachTransform.name);
        //print("attachTransform parent name:" + socket.attachTransform.parent.name);
        //print("attachTransform parent of parent name:" + socket.attachTransform.parent.parent.name);
        //print("attachTransform tag:" + socket.attachTransform.tag);
        if (socket.selectTarget.tag == "Elbow") {
            rotateSocket.transform.localRotation *= Quaternion.Slerp(transform.localRotation, Quaternion.LookRotation(new Vector3(-90, 0, 0)), 1.0f);
        }
    }

    private void MarkChildAsConnected() {
        if (isConnectedToSource) {
            isConnectedToSource = true;
        }
    }
}
