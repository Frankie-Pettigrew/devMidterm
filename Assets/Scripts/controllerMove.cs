using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerMove : MonoBehaviour {
	public Text spedometer;
	CharacterController playerCon;
	bool accelerating;
	bool gliding;
	bool braking;
	bool reversing;

	public float maxSpeed;
	float currentSpeed = 0;
	public float acceleration;
	public float drag = .8f;
	public float brakeForce;

	// Use this for initialization
	void Start () {
		playerCon = GetComponent<CharacterController> (); // save reference to our component
	}
	
	// Update is called once per frame
	void Update () {
		//1. grab input from input devices
		float horizontal = Input.GetAxis ("Horizontal"); //left and right movement
		float vertical = Input.GetAxis ("Vertical"); // up and down movement

		//turn input into bools
		if (vertical > 0) {
			accelerating = true;
			gliding = false;
			braking = false;
			reversing = false;
		} else if (vertical <= .01 && vertical >= -.01f) {
			gliding = true;
			accelerating = false;
			braking = false;
		} else if (vertical < -.01f) {
			braking = true;
			accelerating = false;
			gliding = false;
		}

		//calculate acceleration
		if (accelerating) {
			currentSpeed = .5f;
			if (currentSpeed < maxSpeed) {
				currentSpeed *= acceleration;
			} else if(currentSpeed == maxSpeed) {
				currentSpeed = maxSpeed;
				}
		}
		//decelerate when gliding
		if (gliding) {
			// Debug.Log("gliding");
			if (currentSpeed >= .03f || currentSpeed < 0) {
				currentSpeed *= drag;
			}
			if (currentSpeed <= .03f) {
				currentSpeed = 0;
			}
		}

		//brake 
		if (braking) {
			//Debug.Log ("braking");
			if (currentSpeed >= .001f) {
				currentSpeed *= brakeForce;
			} else {
				reversing = true;
			}
		}

	/*	if (reversing) {
			while (vertical < 0) {
				currentSpeed = -1f;
			}
		} */



		//2. plug your values into the character controller
		playerCon.Move(transform.forward * Time.deltaTime * currentSpeed); // move along forward facing
		if (currentSpeed > 0) {
			transform.Rotate (0f, horizontal * Time.deltaTime * 90f, 0f);
		}

		spedometer.text = currentSpeed.ToString() + "input axis" + vertical.ToString();
		//Debug.Log (vertical);


	}
}