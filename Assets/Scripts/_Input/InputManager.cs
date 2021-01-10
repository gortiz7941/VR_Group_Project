using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class InputManager : MonoBehaviour
{
    public List<ButtonHandler> allButtonHandlers = new List<ButtonHandler>();
    public List<Axis2DHandler> allAxis2DHandlers = new List<Axis2DHandler>();
    public List<AxisHandler> allAxisHandlers = new List<AxisHandler>();

    private XRController controller = null;
    
    private void Awake()
    {
        controller = GetComponent<XRController>();
    }
    
    private void Update() {
        HandleButtonEvents();
        HandleAxis2DEvents();
        HandleAxisEvents();
    }

    private void HandleButtonEvents() {
        foreach (ButtonHandler handler in allButtonHandlers)
            handler.HandleState(controller);
    }

    private void HandleAxis2DEvents() {
        foreach (Axis2DHandler handler in allAxis2DHandlers)
            handler.HandleState(controller);
    }

    private void HandleAxisEvents() {
        foreach (AxisHandler handler in allAxisHandlers)
            handler.HandleState(controller);
    }
}