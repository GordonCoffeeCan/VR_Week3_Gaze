using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 camLookDir = Camera.main.transform.forward;

        //Get direction from player to the target object (PointB - PointA = the Vector3 of PointA to PointB)
        Vector3 vectorForCamToTarget = transform.position - Camera.main.transform.position;

        float angle = Vector3.Angle(camLookDir, vectorForCamToTarget);

        if(angle < 15 * transform.localScale.x) {
            //transform.localScale *= 1.01f;
        }
	}
}
