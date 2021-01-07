﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

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
        DisableGrab();
    }

    private void DisableGrab() {
        if (socket.selectTarget == null) {
            socket.GetComponentInParent<MeshCollider>().enabled = true;
        } else {
            socket.GetComponentInParent<MeshCollider>().enabled = false;
        }
    }
}
