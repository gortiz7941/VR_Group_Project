using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

public class DisableGrabIfSnapped : MonoBehaviour
{
    XRSocketInteractor socket;

    // Start is called before the first frame update
    void Start()
    {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (socket.selectTarget == null) {
            socket.transform.parent.GetComponent<MeshCollider>().enabled = true;
        } else {
            socket.transform.parent.GetComponent<MeshCollider>().enabled = false;
        }
    }
}
