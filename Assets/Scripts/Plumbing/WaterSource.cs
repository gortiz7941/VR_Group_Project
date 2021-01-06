using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class WaterSource : MonoBehaviour {
    XRRig rig;
    XRController right;
    XRBaseControllerInteractor interactor;
    XRRayInteractor ray;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<XRRig>();
        right = GetComponent<XRController>();
        interactor = GetComponent<XRBaseControllerInteractor>();
        ray = GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other) {

        if (other.gameObject.name == "Elbow") {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.transform.parent = other.gameObject.transform;
            gameObject.transform.localRotation = Quaternion.identity;
            gameObject.transform.localPosition = new Vector3(0f, -3f, 37f);

            //right.enableInputActions = false;
        }
    }

    private void OnTriggerExit(Collider other) {
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
        //gameObject.transform.parent = null;
    }
}
