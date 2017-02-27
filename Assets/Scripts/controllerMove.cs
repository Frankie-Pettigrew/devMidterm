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
	float lerpT;
	float lerpMax;
	float lerpMin;


	public float maxSpeed;
	float currentSpeed = 0;
	public float acceleration;
	public float drag = .8f;
	public float brakeForce;


	public void rotateZ(float axis) {
		float yVal = transform.eulerAngles.y;
		float maxRot = 15;
		float rate = 0f;
		float angle = 0;
		bool right = false;
		bool left = false;
		//axis = Mathf.Lerp (-1, 1, 0.5f);
		yVal += -axis;
		if (Input.GetKey(KeyCode.D)) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, Mathf.LerpAngle (transform.eulerAngles.z, -15, 2f * Time.deltaTime));
		} else if (Input.GetKey(KeyCode.A)) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, Mathf.LerpAngle (transform.eulerAngles.z, 15, 2f * Time.deltaTime));
		} else {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, Mathf.LerpAngle (transform.eulerAngles.z, 0, 3f * Time.deltaTime));

		}
		//float angle = Mathf.LerpAngle(-15, 15, 0.2f * rate);
		//transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, angle);
	}

	// Use this for initialization
	void Start () {
		playerCon = GetComponent<CharacterController> (); // save reference to our component
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		//1. grab input from input devices
		float horizontal = Input.GetAxis("Horizontal"); //left and right movement
		float vertical = Input.GetAxis ("Vertical"); // up and down movement

		if (Input.GetKeyDown (KeyCode.Space)) {
			gameObject.GetComponent<AudioSource> ().Play ();
		}

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
			if (currentSpeed == 0) {
				currentSpeed = .5f;
			}
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
			} /*else {
				reversing = true;
			}*/
		}

	/*	if (reversing) {
			while (vertical < 0) {
				currentSpeed = -1f;
			}
		} */



		//2. plug your values into the character controller
		Vector3 movement = transform.forward * Time.deltaTime * currentSpeed;
		movement.y = 0;
		//lerpT += horizontal * 5;

		

		playerCon.Move(movement); // move along forward facing
		if (currentSpeed > 0) {
			rotateZ (-horizontal);
			//transform.eulerAngles  += new Vector3(transform.eulerAngles.x, horizontal * Time.deltaTime * 90f, transform.eulerAngles.z);
			//transform.eulerAngles =  new Vector3 (0, transform.eulerAngles.y, Mathf.Lerp(lerpMin, lerpMax, lerpT));

		}

		spedometer.text = currentSpeed.ToString() + "input axis" + vertical.ToString();
		//Debug.Log (vertical);


	}

}