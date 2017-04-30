using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleMovement : MonoBehaviour {

    float velocity = 1000; //10 meters per second

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {
        GetComponent<Rigidbody>().MovePosition(transform.position -Vector3.right * velocity * Time.deltaTime);
	}
}
