using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPipe : MonoBehaviour {

    public Transform Part;
    public Transform pipeEndFront;
    public Transform pipeEndBack;

    public GameObject pipe_a;
    public GameObject pipe_b;

    // Start is called before the first frame update
    void Start()
    {
        FixedJoint ConnectorFront = GetComponent<FixedJoint>();
        FixedJoint ConnectorBack = GetComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        pipe_a.AddComponent<HingeJoint>();
    }

    void AttachTo(Transform otherConnector) {
        Transform oldParent = Part.parent;
    }
}

/*
public Transform target;
public float snapDistance = 1f;

void FixedUpdate() {
    if (target == null) return;

    if ( Vector3.Distance(transform.position, target.transform.position) <= snapDistance)   
    {
        target.transform.parent = transform;
        target.transform.localRotation = Quaternion.identity;
        target.transform.localPosition = Vector3.zero;

        //target.GetComponent<HingeJoint>().connectedBody = ;
    }
}
*/
