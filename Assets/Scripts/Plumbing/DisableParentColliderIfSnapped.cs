using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableParentColliderIfSnapped : MonoBehaviour {
    XRSocketInteractor socket;
    XRGrabInteractable grab;

    // Start is called before the first frame update
    void Start() {

        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update() {
        DisableGrab();
    }

    private void DisableGrab() {
        if (!socket.selectTarget && socket.transform.parent.GetComponentInChildren<CapsuleCollider>()) {
            socket.transform.parent.GetComponentInChildren<CapsuleCollider>().enabled = false;
        } else if (socket.selectTarget) {
            socket.transform.parent.GetComponentInChildren<CapsuleCollider>().enabled = true;
        }
    }
}