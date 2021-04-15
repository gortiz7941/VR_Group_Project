using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeSocket : XRSocketInteractor {
    
    public Pipe ThisPipe { get; protected set; }
    public Pipe ConnectedPipe { get; protected set; }

    protected override void Start() {
        ThisPipe = GetComponentInParent<Pipe>();
        ConnectedPipe = null;
    }

    protected virtual void Update() {
        // If there is a pipe in this socket....
        if (selectTarget != null && ConnectedPipe == null) {
            ThisPipe.DisableGrab();

            // Mark this socket as containing that pipe and vice versa.
            ConnectedPipe = selectTarget.GetComponentInParent<Pipe>();
            ConnectedPipe.socketConnectedTo = this;

            // Turn on the sockets of the connected pipe.
            foreach (PipeSocket socket in ConnectedPipe.GetComponentsInChildren<PipeSocket>()) {
                socket.socketActive = true;
            }

            // If there is not a pipe in this socket...
        } else if (selectTarget == null && ConnectedPipe != null) {
            ThisPipe.EnableGrab();

            // Turn off the sockets of the connected pipe.
            foreach (PipeSocket socket in ConnectedPipe.GetComponentsInChildren<PipeSocket>()) {
                socket.socketActive = false;
            }

            // Unmark that pipe as containing this socket and vice versa.
            ConnectedPipe.socketConnectedTo = null;
            ConnectedPipe = null;
        }
    }
}

