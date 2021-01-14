using UnityEngine;

public class Pipe : MonoBehaviour {
    public PipeSocket socketConnectedTo;
    public bool isConnectedToSource = false;

    protected virtual void Start() { }
    protected virtual void Update() {
        if (socketConnectedTo != null && (socketConnectedTo.tag == "WaterSource" || socketConnectedTo.ThisPipe.isConnectedToSource == true)) {
            isConnectedToSource = true;
        } else {
            isConnectedToSource = false;
        }
    }

    //*************************************************************
    // Disable grabbing of the pipe. This is done by imposing an
    // invisible and non-interactable collider over the pipe model.
    //*************************************************************
    public void DisableGrab() {
        if (!transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
            transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = true;
        }
    }

    public virtual void EnableGrab() {
        if (transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled) {
            transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = false;
        }
    }


    private void OnCollisionEnter(Collision collision) {
        print("Collision detected...");
        if (collision.collider.GetComponent<Appliance>() != null) {
            print("You win by collision?");
            if (isConnectedToSource) {
                print("Yep, you win by collision!");
            }
        }
    }

    public void OnTriggerEnter(Collider other) {
        print("Trigger entered...");
        if (other.GetComponent<Appliance>() != null) {
            print("You win by trigger?");
            if (isConnectedToSource) {
                print("Yep, you win by trigger!");
            }
        }

    }
}
