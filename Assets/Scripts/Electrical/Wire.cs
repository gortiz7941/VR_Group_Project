using UnityEngine;

public class Wire : MonoBehaviour
{
    public WireSocket socketConnectedTo;
    public bool isConnectedToSource = false;

    protected virtual void Start() { }
    protected virtual void Update()
    {
        if (socketConnectedTo != null && (socketConnectedTo.tag == "ElectricitySource" || socketConnectedTo.ThisWire.isConnectedToSource == true))
        {
            isConnectedToSource = true;
        }
        else
        {
            isConnectedToSource = false;
        }
    }

    //*************************************************************
    // Disable grabbing of the wire. This is done by imposing an
    // invisible and non-interactable collider over the wire model.
    //*************************************************************
    public void DisableGrab()
    {
        if (!transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled)
        {
            transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = true;
        }
    }

    public virtual void EnableGrab()
    {
        if (transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled)
        {
            transform.Find("PreventGrab").GetComponentInChildren<Collider>().enabled = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FinalGang>() != null && isConnectedToSource)
        {
            GameObject.Find("GameSession").GetComponent<GameSession>().WinGame();
        }
    }
}