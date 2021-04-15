using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PreventCollisionsOnUnsocketing : MonoBehaviour {
    private MeshCollider thisCollider;
    public float timeToPreventCollisions = 0.2f;
    private XRSocketInteractor thisInteractor;
    private XRBaseInteractable thisInteractable;

    // Start is called before the first frame update
    void Start()
    {
        thisInteractor = GetComponent<XRSocketInteractor>();
        thisInteractor.onSelectExited.AddListener(PreventCollisions);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PreventCollisions(XRBaseInteractable interactable) {
        thisCollider = interactable.GetComponentInChildren<MeshCollider>();
        StartCoroutine(ToggleCollisionsOnOff());
    }

    private IEnumerator ToggleCollisionsOnOff() {
        //yield return new WaitForFixedUpdate();
        yield return new WaitUntil(() => !thisInteractor.selectTarget);
        thisCollider.enabled = false;
        yield return new WaitForSeconds(timeToPreventCollisions);
        thisCollider.enabled = true;
    }
}
