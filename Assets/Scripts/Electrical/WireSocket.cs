using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WireSocket : XRSocketInteractor
{

    public Wire ThisWire { get; protected set; }
    public Wire ConnectedWire { get; protected set; }

    protected override void Start()
    {
        ThisWire = GetComponentInParent<Wire>();
    }

    protected virtual void Update()
    {
        // If there is a pipe in this socket....
        if (selectTarget != null && ConnectedWire == null)
        {
            ThisWire.DisableGrab();

            // Mark this socket as containing that pipe and vice versa.
            ConnectedWire = selectTarget.GetComponentInParent<Wire>();
            ConnectedWire.socketConnectedTo = this;

            // Turn on the sockets of the connected pipe.
            foreach (WireSocket socket in ConnectedWire.GetComponentsInChildren<WireSocket>())
            {
                socket.socketActive = true;
            }

            // If there is not a pipe in this socket...
        }
        else if (selectTarget == null && ConnectedWire != null)
        {
            ThisWire.EnableGrab();

            // Turn off the sockets of the connected pipe.
            foreach (WireSocket socket in ConnectedWire.GetComponentsInChildren<WireSocket>())
            {
                socket.socketActive = false;
            }

            // Unmark that pipe as containing this socket and vice versa.
            ConnectedWire.socketConnectedTo = null;
            ConnectedWire = null;
        }
    }
}

