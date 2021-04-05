using System;
using System.Collections;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PreventCollisionsOnGrab : MonoBehaviour
{
    private MeshCollider thisCollider;
    public float timeToPreventCollisions = 0.2f;

    /*
    public XRGrabInteractable interactable;
    public XRRayInteractor controllerGrabber;
    public float timeToPreventCollisions = 0.2f;
    private void Start() {
        thisCollider = GetComponentInChildren<MeshCollider>();
        interactable.onSelectEntered.AddListener(PreventCollisions);
        interactable.onSelectExited.AddListener(PreventCollisions);
    }

    private void PreventCollisions(XRBaseInteractor interactor) {
        StartCoroutine(ToggleCollisionsOnOff());
    }

    private IEnumerator ToggleCollisionsOnOff() {
        thisCollider.enabled = false;
        yield return new WaitForSeconds(timeToPreventCollisions);
        thisCollider.enabled = true;
    }
    */

    private XRRayInteractor thisInteractor;

    private void Start() {
        thisInteractor = GetComponent<XRRayInteractor>();
        //thisInteractor.onSelectEntered.AddListener(IncreaseMass);
        //thisInteractor.onSelectExited.AddListener(DecreaseMass);
        thisInteractor.onHoverEntered.AddListener(CheckIfConnected);
        thisInteractor.onSelectExited.AddListener(PreventCollisions);
    }

    private void Update() {
    }

    private void CheckIfConnected(XRBaseInteractable interactable) {
        if (!interactable.isSelected) {
            thisInteractor.onSelectEntered.AddListener(PreventCollisions);
        }
    }

    private void PreventCollisions(XRBaseInteractable interactable) {
        thisCollider = interactable.GetComponentInChildren<MeshCollider>();
        StartCoroutine(ToggleCollisionsOnOff());
    }

    private IEnumerator ToggleCollisionsOnOff() {
        thisCollider.enabled = false;
        yield return new WaitForSeconds(timeToPreventCollisions);
        thisCollider.enabled = true;
        thisInteractor.onSelectEntered.RemoveListener(PreventCollisions);
    }

    /*
    private void DecreaseMass(XRBaseInteractable interactable) {
        interactable.GetComponent<Rigidbody>().mass = 0.001f;
    }

    private void IncreaseMass(XRBaseInteractable interactable) {
        interactable.GetComponent<Rigidbody>().mass = 1.0f;
    }
    */
}
