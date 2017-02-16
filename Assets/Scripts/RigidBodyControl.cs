using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyControl : MonoBehaviour {

	Rigidbody rb;

	Vector3 inputVector;

	bool isGrounded;

	public float maxSpeed = 5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //cache reference for our shortcut
	}
	
	// get player input in Update
	void Update () {
		//MOVEMENT
		float horizontal = Input.GetAxis ("Horizontal"); // Left/Right, A/D
		float vertical = Input.GetAxis ("Vertical"); //Up/Down, W/S

		inputVector = new Vector3 (horizontal, 0f, vertical);

		//TURNING 
		transform.Rotate(0f, Input.GetAxis("Mouse X") * Time.deltaTime * 180f, 0f);
		//DO GROUNDED CHECK: shoot raycast just a little past bottom of capsule
		isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
		//JUMPING
		if (Input.GetKeyDown (KeyCode.Space) && isGrounded) {
			inputVector.y = 60f;
		}
	}
	// this is the framerate where physics runs
	void FixedUpdate() {
		//apply y movement force
		rb.AddRelativeForce (Vector3.up * inputVector.y * 10f);
		//apply x/z movement force
		if(rb.velocity.magnitude < maxSpeed) {
			rb.AddRelativeForce (inputVector * 10f);
		}
			

	}
}
