using UnityEngine;
using System.Collections;

public class FrogMovement : MonoBehaviour {

    public float jumpElevationInDegrees = 45;
    public float jumpSpeedMPS = 5;
    public float jumpGroundClearance = 2;
    public float jumpSpeedTolerance = 5;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        bool isOnGround = Physics.Raycast(transform.position, -transform.up, jumpGroundClearance);
        Debug.DrawRay(transform.position, -transform.up * jumpGroundClearance);
        var speed = GetComponent<Rigidbody>().velocity.magnitude;
        bool isNearStationary = speed < jumpSpeedTolerance;

        //  Input.GetKeyDown(KeyCode.Space)
        if (GvrViewer.Instance.Triggered && isOnGround && isNearStationary)
        {
            var camera = GetComponentInChildren<Camera>();
            Debug.DrawLine(transform.position, camera.transform.forward, Color.black);
            var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.up);
            Debug.DrawLine(transform.position, projectedLookDirection, Color.blue);
            var radiansToRotate = Mathf.Deg2Rad * jumpElevationInDegrees;
            var unnormalizedJumpDirection = Vector3.RotateTowards(projectedLookDirection, Vector3.up, radiansToRotate, 0);
            var jumpVector = unnormalizedJumpDirection.normalized * jumpSpeedMPS;
            Debug.DrawLine(transform.position, jumpVector, Color.cyan);

            GetComponent<Rigidbody>().AddForce(jumpVector, ForceMode.VelocityChange);
        }
	}
}
