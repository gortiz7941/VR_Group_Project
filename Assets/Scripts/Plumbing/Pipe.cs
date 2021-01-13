using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Pipe : MonoBehaviour
{

    protected XRSocketInteractor socket;
    protected XRSocketInteractor connectedPipeSocket;

    protected GameObject connectedPipe;
    protected GameObject pipeConnectedTo;
    //private bool isConnectedToSource = false;

    // Start is called before the first frame update
    protected virtual void Start() {
        socket = gameObject.GetComponentInChildren<XRSocketInteractor>();
    }

    // Update is called once per frame
    protected virtual void Update() {
        UpdateConnectedPipes();
        EnableSnap();
        DisableGrab();
        MarkChildAsConnected();
    }

    private void UpdateConnectedPipes() {
        if (socket.selectTarget) {
            connectedPipe = socket.selectTarget.gameObject;
            connectedPipeSocket = socket.selectTarget.GetComponentInChildren<XRSocketInteractor>();
            socket.selectTarget.GetComponentInChildren<Pipe>().pipeConnectedTo = gameObject;
        }
    }

    //********************************************
    // Enables the snap point on a connected pipe.
    //********************************************
    private void EnableSnap() {

        // Check to ensure this pipe has another pipe connected to it.
        if (socket.selectTarget) {

            // If this pipe has another pipe connected to it, activate the connected pipe's socket if it exists.
            if (connectedPipeSocket = socket.selectTarget.GetComponentInChildren<XRSocketInteractor>()) {
                connectedPipeSocket.socketActive = true;
            }

        // Check that this pipe does not have another pipe connected.
        } else {

            // if there is a connected pipe socket stored, there was a pipe connected to this pipe,
            // and it has been disconnected. Disable the socket of the disconnected pipe, then set 
            // the connected socket to null to signify that the disconnected pipe is disconnected.
            if (connectedPipeSocket != null) {
                connectedPipeSocket.socketActive = false;
                connectedPipeSocket = null;
            }
        }
    }

    //**************************************************************************
    // Makes an object ungrabbable if the pipe has another pipe connected to it.
    //**************************************************************************
    private void DisableGrab() {

        // If this pipe has another pipe connected to it, disable grabbing this pipe.
        if (socket.selectTarget && !socket.transform.parent.Find("PreventGrab").GetComponent<Collider>().enabled) {
            if (!socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
                socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = true;
            }

        // If this pipe doesn't have another pipe connected to it, enable grabbing this pipe.
        } else if (!socket.selectTarget && socket.transform.parent.Find("PreventGrab").GetComponent<Collider>()) {
            if (socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
                socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = false;
            }
        }
    }

    //*********************************************************
    // Marks a connected pipe as connected to the water source.
    //*********************************************************
    private void MarkChildAsConnected() {
    }
}
