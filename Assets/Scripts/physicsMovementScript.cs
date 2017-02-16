using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class physicsMovementScript : MonoBehaviour {

	Rigidbody rb;

	Vector3 inputVector;

	public float maxSpeed = 6f;

	float drag = .1f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> (); //caching reference
	}
	
	// Update is called once per frame
	void Update () {
		//get steering input
		float horizontal = Input.GetAxis ("Horizontal");
		//acceleration and braking input
		float vertical = Input.GetAxis("Vertical");

		inputVector = new Vector3 (horizontal, 0f, vertical);

		//steering controls based on input vector
		//transform.Rotate(0f, inputVector.x * Time.deltaTime * 180f, 0f);
		
	}

	void FixedUpdate() {
		
		//apply acceleration if under maxspeed with vertical input axis
		if (rb.velocity.magnitude < maxSpeed) {
			rb.AddRelativeForce (transform.forward * inputVector.z * Time.deltaTime * 180f);
		}
		//trying torque
		rb.AddTorque(0f, inputVector.x * Time.deltaTime, 0f);
		rb.drag = drag;

	}
}
