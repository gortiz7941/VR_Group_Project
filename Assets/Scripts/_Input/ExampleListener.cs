using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour {
    public ButtonHandler primaryAxisClickHandler = null;
    public Axis2DHandler primaryAxisHandler = null;
    public AxisHandler triggerHandler = null;

    public void OnEnable() {
        primaryAxisClickHandler.OnButtonDown += PrintPrimaryButtonDown;
        primaryAxisHandler.OnValueChange += PrintPrimaryAxis;
        triggerHandler.OnValueChange += PrintTrigger;
    }

    public void OnDisable() {
        primaryAxisClickHandler.OnButtonDown -= PrintPrimaryButtonDown;
    }

    private void PrintPrimaryButtonDown(XRController controller) {
        print("Primary button down.");
    }

    private void PrintPrimaryAxis(XRController controller, Vector2 value) {
        print("Primary axis: " + value);
    }

    private void PrintTrigger(XRController controller, float value) {
        print("Trigger: " + value);
    }
}
