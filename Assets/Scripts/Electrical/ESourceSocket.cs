public class ESourceSocket : WireSocket
{
    protected override void Start() { }

    protected override void Update()
    {

        if (selectTarget != null && ConnectedWire == null)
        {

            // Mark this socket as containing that wire and vice versa.
            ConnectedWire = selectTarget.GetComponentInParent<Wire>();
            ConnectedWire.socketConnectedTo = this;

            // Turn on the sockets of the connected wire.
            foreach (WireSocket socket in ConnectedWire.GetComponentsInChildren<WireSocket>())
            {
                socket.socketActive = true;
            }

            // If there is not a wire in this socket...
        }
        else if (selectTarget == null && ConnectedWire != null)
        {

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