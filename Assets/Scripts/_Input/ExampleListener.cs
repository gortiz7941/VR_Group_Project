using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour {
    public ButtonHandler primaryAxisClickHandler = null;
    public Axis2DHandler primaryAxisHandler = null;
    public AxisHandler triggerHandler = null;
    
    public Transform target;
    public float rotateTime = 3.0f;
    public float rotateDegrees = 90.0f;
    private bool rotating = false;

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

        XRRayInteractor ray = controller.GetComponent<XRRayInteractor>();
        if (ray.selectTarget?.tag == "T") {
            //ray.selectTarget.transform.Rotate(0, 90, 0);
            target = ray.selectTarget.transform;
            print("Starting Coroutine...");
            StartCoroutine(Rotate(transform, target, Vector3.up, -rotateDegrees, rotateTime));
        }
    }

    private void PrintPrimaryAxis(XRController controller, Vector2 value) {
        print("Primary axis: " + value);
    }

    private void PrintTrigger(XRController controller, float value) {
        print("Trigger: " + value);
    }

    public IEnumerator Rotate (Transform camTransform, Transform targetTransform, Vector3 rotateAxis, float degrees, float totalTime) {
        if (rotating) {
            print("Rotating....");
            yield return null;
        }

        rotating = true;
        print("Rotating: true");

        Quaternion startRotation = camTransform.rotation;
        Vector3 startPosition = camTransform.position;
        transform.RotateAround(targetTransform.position, rotateAxis, degrees);
        Quaternion endRotation = camTransform.rotation;
        Vector3 endPosition = camTransform.position;
        camTransform.rotation = startRotation;
        camTransform.position = startPosition;

        float rate = degrees / totalTime;
        for (float i = 0.0f; Mathf.Abs(i) < Mathf.Abs(degrees); i += Time.deltaTime / rate) {
            print("For loop....");
            camTransform.RotateAround(targetTransform.position, rotateAxis, Time.deltaTime * rate);
            yield return null;
        }

        print("Translating finalizing.");
        camTransform.rotation = endRotation;
        camTransform.position = endPosition;
        rotating = false;
    }
}
