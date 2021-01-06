using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachablePipe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //GameObject pipe = GameObject.Find("PipeStraightMetal");
        GameObject snapPoint = GameObject.Find("SourceSnapPoint");

        AttachPipe snapper = snapPoint.GetComponent<AttachPipe>();
     //   snapper.target = gameObject;
     //   snapper.snapDistance = 1f;
    }
}
