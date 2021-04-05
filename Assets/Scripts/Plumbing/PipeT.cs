using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class PipeT : Pipe {
    XRController controller;
    XRRayInteractor ray;
    RaycastHit hit;
    public AudioClip rotationSoundClip;
    bool isHit = false;
    bool previousPress = false;

    protected override void Start() {
        base.Start();
        controller = GameObject.Find("RightHand Controller").GetComponent<XRController>();
        ray = controller.GetComponent<XRRayInteractor>();
    }

    protected override void Update() {
        base.Update();
        RotateOnPrimaryButtonPress();
    }

    //*******************************************************
    // Rotates a pipe 90 degrees if the player presses a primary button.
    // ******************************************************
    private void RotateOnPrimaryButtonPress() {
        if (ray) {
            isHit = ray.GetCurrentRaycastHit(out hit);

            if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool buttonValue) && isHit && hit.transform.gameObject == gameObject) {
                if (socketConnectedTo != null && !IsConnected()) {
                    XRSocketInteractor rotateSocket = hit.transform.GetComponent<PipeT>().socketConnectedTo;
                    if (previousPress != buttonValue) {
                        previousPress = buttonValue;

                        if (buttonValue == true) {
                            rotateSocket.attachTransform.localRotation *= Quaternion.Euler(new Vector3(0, 0, 90));
                            audioSource.clip = rotationSoundClip;
                            audioSource.Play();
                        }
                    }
                }
            }
        }
    }

    private bool IsConnected() {
        bool isConnected = false;
        foreach (PipeSocket socket in GetComponentsInChildren<PipeSocket>()) {
            if (socket.selectTarget != null) {
                isConnected = true;
            }
        }
        return isConnected;
    }

    public override void EnableGrab() {
        if (!IsConnected()) {
            base.EnableGrab();
        }
    }
}
