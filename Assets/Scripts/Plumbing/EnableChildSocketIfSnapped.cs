using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class EnableChildSocketIfSnapped : MonoBehaviour {

    private XRSocketInteractor socket;
    private XRSocketInteractor childSocket;


    // Start is called before the first frame update
    void Start()
    {
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
        if (socket && socket.selectTarget) {
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