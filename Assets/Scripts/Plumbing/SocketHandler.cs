using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

//[CreateAssetMenu(fileName = "NewSocketHandler")]
public class SocketHandler {
    public XRSocketInteractor socket = null;

    public delegate XRSocketInteractor SocketDelegate(XRSocketInteractor socket);
    public SocketDelegate elbowSocketDelegate;

    

    XRSocketInteractor ReturnSocket() {
        return socket;
    }
}
