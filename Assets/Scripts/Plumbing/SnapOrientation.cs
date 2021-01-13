using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapOrientation : MonoBehaviour {
    public Vector3 elbowPosition;
    public Vector3 elbowRotation;

    public Vector3 pipePosition;
    public Vector3 pipeRotation;

    public void SetOrientation(XRSocketInteractor socket) {
        XRBaseInteractable target = socket.selectTarget;
        //print("Target selected..." + socket.selectTarget.name);

        if (socket.selectTarget.tag == "Elbow") {
            socket.attachTransform.localPosition = elbowPosition;
            socket.attachTransform.localRotation = Quaternion.Slerp(socket.attachTransform.localRotation, Quaternion.Euler(elbowRotation), 100f * Time.deltaTime);
        }

        if (socket.selectTarget.tag == "Pipe") {
            socket.attachTransform.localPosition = pipePosition;
            socket.attachTransform.localRotation = Quaternion.Euler(pipeRotation);
        }
    }
}
