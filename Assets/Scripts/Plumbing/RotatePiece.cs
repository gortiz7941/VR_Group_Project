using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class RotatePiece : MonoBehaviour
{
    private XRController controller;

    private void Awake() {
        controller = GetComponent<XRController>();
    }
    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindObjectOfType<XRController>();
        bool pressed;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        string output = string.Empty;

        if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out bool axisClick)) {
            output += "Primary 2D Axis Click: " + axisClick + "\n";
        }
    }
}
