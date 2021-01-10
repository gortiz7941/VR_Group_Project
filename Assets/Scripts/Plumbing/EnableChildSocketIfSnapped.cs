using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableChildSocketIfSnapped : MonoBehaviour {

    XRSocketInteractor socket;
    XRSocketInteractor childSocket;

    // Start is called before the first frame update
    void Start()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        EnableSnap();
    }

    private void EnableSnap() {
        if (socket.selectTarget != null) {
            childSocket = socket.selectTarget.GetComponentInChildren<XRSocketInteractor>();
            childSocket.socketActive = true;
        } else {
            if (childSocket != null) {
                childSocket.socketActive = false;
                childSocket = null;
            }
        } 
    }
}