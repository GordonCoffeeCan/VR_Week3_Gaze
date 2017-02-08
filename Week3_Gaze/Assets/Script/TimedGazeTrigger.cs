using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TimedGazeTrigger : MonoBehaviour {

    //[SerializeField] means to show private variable on the Inspector;
    [SerializeField]private float timeLookedAt = 0;//time, in seconds, we've spent looking at this thing;
    private Image progressImage;

    public UnityEvent OnGazeComplete = new UnityEvent();

	// Use this for initialization
	void Start () {
        progressImage = GameObject.Find("Image").GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 camLookDir = Camera.main.transform.forward;

        //Get direction from player to the target object (PointB - PointA = the Vector3 of PointA to PointB)
        Vector3 vectorForCamToTarget = transform.position - Camera.main.transform.position;

        float angle = Vector3.Angle(camLookDir, vectorForCamToTarget);

        if(angle < 5) {
            timeLookedAt = Mathf.Clamp01(timeLookedAt + Time.deltaTime); //after 1 second, tshi variable will be 1;

            if(timeLookedAt == 1) {
                timeLookedAt = 0;
                OnGazeComplete.Invoke();
            }
        } else {
            //"Decay" progress if we are not looking at it;
            timeLookedAt = Mathf.Clamp01(timeLookedAt - Time.deltaTime);
        }

        progressImage.fillAmount = timeLookedAt; //fillAmount is a float from 0 to 1;
	}
}
