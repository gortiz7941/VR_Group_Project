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
        // Checks to see if a wire is connected to the selected object.
        if (selectTarget != null && ConnectedWire == null)
        {
            //Disables grab ability of selected wire.
            ThisWire.DisableGrab();

            // Linking selected object's socket to wire being connected.
            ConnectedWire = selectTarget.GetComponentInParent<Wire>();
            ConnectedWire.socketConnectedTo = this;

            // Turn on the sockets of the connected wire.
            foreach (WireSocket socket in ConnectedWire.GetComponentsInChildren<WireSocket>())
            {
                socket.socketActive = true;
            }

     
        }
        else if (selectTarget == null && ConnectedWire != null)
        {
            ThisWire.EnableGrab();

            // Turn off the sockets of the connected wire.
            foreach (WireSocket socket in ConnectedWire.GetComponentsInChildren<WireSocket>())
            {
                socket.socketActive = false;
            }

            // Unmark that wire as containing this socket and vice versa.
            ConnectedWire.socketConnectedTo = null;
            ConnectedWire = null;
        }
    }
}

