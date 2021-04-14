using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Pipe : MonoBehaviour {
    public PipeSocket socketConnectedTo;
    public bool isConnectedToSource = false;
    protected AudioSource audioSource;
    public AudioClip[] pipeImpactClips;
    Vector3 startPosition;
    Quaternion startRotation;

    protected virtual void Start() {
        startPosition = transform.position;
        startRotation = transform.rotation;
        Invoke("SetAudioSource", 1);
    }
    protected virtual void Update() {

        // Win condition
        if (socketConnectedTo != null && (socketConnectedTo.tag == "WaterSource" || socketConnectedTo.ThisPipe.isConnectedToSource == true)) {
            isConnectedToSource = true;
        } else {
            isConnectedToSource = false;
        }
        
        // Bring pipe back to table if it falls out of bounds.
        if (transform.position.y < -3) {
            transform.position = startPosition;
            transform.rotation = startRotation;
        }
    }

    private void SetAudioSource() {
        audioSource = transform.Find("CollisionSoundEffect").GetComponent<AudioSource>();
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

    public void OnTriggerEnter(Collider other) {
        if (other.GetComponent<Appliance>() != null && isConnectedToSource) {
            GameObject.Find("GameSession").GetComponent<GameSession>().WinGame();
        }
    }

    public void OnCollisionEnter(Collision collision) {
        if (audioSource && !audioSource.isPlaying) {
            int clipSelector = Random.Range(0, pipeImpactClips.Length-1);
            audioSource.clip = pipeImpactClips[clipSelector];
            audioSource.Play();
        }
    }
}