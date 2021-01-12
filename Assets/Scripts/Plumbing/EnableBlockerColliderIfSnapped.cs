using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class EnableBlockerColliderIfSnapped : MonoBehaviour {
    XRSocketInteractor socket;

    // Start is called before the first frame update
    void Start() {
        socket = gameObject.GetComponent<XRSocketInteractor>();
    }

    // Update is called once per frame
    void Update() {
        DisableGrab();
    }

    private void DisableGrab() {
        if (!socket.selectTarget && socket.transform.parent.Find("PreventGrab").GetComponent<Collider>()) {
            if (socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
                print("Collider disabled.");
                socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = false;
            }
        } else if (socket.selectTarget && !socket.transform.parent.Find("PreventGrab").GetComponent<Collider>().enabled) {
            print("Socket target: " + socket.selectTarget.name);
            if (!socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
                print("Collider enabled.");
                socket.transform.parent.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = true;
            }
        }
    }
}