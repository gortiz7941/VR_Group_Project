using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapToMultiplePoints : MonoBehaviour {
    XRSocketInteractor socket;
    XRGrabInteractable grabber;

    // Start is called before the first frame update
    void Start() {
        //socket = gameObject.GetComponent<XRSocketInteractor>();
        grabber = gameObject.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        if (socket = other.gameObject.GetComponentInChildren<XRSocketInteractor>()) {
            //print("Collided with socket, trigger");
        }
        print(gameObject.name);
        gameObject.GetComponentInParent<XRGrabInteractable>().attachTransform = gameObject.transform;
    }

    private void OnCollisionEnter(Collision collision) {
        if (socket = collision.collider.gameObject.GetComponentInChildren<XRSocketInteractor>()) {
            print("Collided with socket, collider");
        }
    }
}
