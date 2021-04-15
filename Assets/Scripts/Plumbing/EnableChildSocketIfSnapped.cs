using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class EnableChildSocketIfSnapped : MonoBehaviour {

    private XRSocketInteractor socket;
    private XRSocketInteractor childSocket;


    void Start() {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }
    
    void Update() {
        EnableSnap();
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
}