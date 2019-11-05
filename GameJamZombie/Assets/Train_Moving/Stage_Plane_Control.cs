using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Plane_Control : MonoBehaviour {

	GameObject stagePlane;
	public GameObject startPosition;
	float speed;
	// Use this for initialization
	void Start () {
		speed = 20f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3(1, 0, 0) * speed * Time.deltaTime);
	}

	// For when the object collides with the trigger
	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("Inside Trigger");
		Parallax ();
	}
		
	// Controls the scrolling of the stage planes
	void Parallax () 
	{
		transform.position = startPosition.transform.position;
	}
}
