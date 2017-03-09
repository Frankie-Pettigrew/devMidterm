using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controllerMove : MonoBehaviour {
	public static GameObject spedometer;
	public GameObject carModel;
	public static Text text;
	CharacterController playerCon;
	bool accelerating;
	bool gliding;
	bool braking;
	bool reversing;
	bool moving;
	public float lerpT;

	public float maxSpeed;
	public float currentSpeed = 0;
	public float acceleration;
	public float accelerationChange;
	public float drag = .8f;
	public float brakeForce;
	public float idleSpeed;
	public float accelerationCap;


	public void rotateZ(float axis) {
		float yVal = transform.eulerAngles.y;
		yVal += -axis * 1.8f;

		if (Input.GetKey(KeyCode.D) && currentSpeed >= maxSpeed) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, Mathf.LerpAngle (transform.eulerAngles.z, -10, lerpT * Time.deltaTime));
		} else if (Input.GetKey(KeyCode.A) && currentSpeed >= maxSpeed) {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, Mathf.LerpAngle (transform.eulerAngles.z, 10, lerpT * Time.deltaTime));
		} else {
			transform.eulerAngles = new Vector3 (transform.eulerAngles.x, yVal, Mathf.LerpAngle (transform.eulerAngles.z, 0, 3f * Time.deltaTime));
		}
	}

	// Use this for initialization
	void Start () {
		playerCon = GetComponent<CharacterController> (); // save reference to our component
		transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		spedometer = GameObject.FindGameObjectWithTag ("text");
		text = spedometer.GetComponent<Text> ();
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
			moving = true;
			if (currentSpeed == 0) {
				currentSpeed = idleSpeed;
			}
			if (currentSpeed == idleSpeed) {
				acceleration = 0.05f;
				accelerationChange = 0.1f;
			}
			if (currentSpeed < maxSpeed) {
				if (acceleration < accelerationCap) {
					acceleration += accelerationChange;
				}
				currentSpeed += acceleration;
			} else if(currentSpeed >= maxSpeed) {
				currentSpeed = maxSpeed;
				}
		}
		//decelerate when gliding
		if (gliding) {
			// Debug.Log("gliding");
			if (currentSpeed >= .03f || currentSpeed < 0) {
				if (currentSpeed != idleSpeed) {
					currentSpeed *= drag;
					acceleration *= drag;
				}
			}
			if (currentSpeed <= .3f) {
				currentSpeed = 0;
				moving = false;
			}
		}

		//brake 
		if (braking) {
			//Debug.Log ("braking");
			if (currentSpeed >= .001f) {
				currentSpeed *= brakeForce;
				carModel.transform.eulerAngles = new Vector3 (Mathf.LerpAngle (carModel.transform.eulerAngles.x, 10, lerpT * Time.deltaTime), carModel.transform.eulerAngles.y, carModel.transform.eulerAngles.z);
			} else if (moving == false) {
				reversing = true;
			}
		} else {
			carModel.transform.eulerAngles = new Vector3 (Mathf.LerpAngle (carModel.transform.eulerAngles.x, 0, lerpT * Time.deltaTime), carModel.transform.eulerAngles.y, carModel.transform.eulerAngles.z);
		}

		if (reversing) {
			if (braking) {
				currentSpeed = -0.6f;
			} else {
				currentSpeed *= drag;
			}
		} 



		//2. plug your values into the character controller
		Vector3 movement = transform.forward * Time.deltaTime * currentSpeed;
		movement.y = 0;
		//lerpT += horizontal * 5;

		

			playerCon.Move(movement); // move along forward facing
			rotateZ (-horizontal);
		

		//text.text = (/*Time.deltaTime * */currentSpeed).ToString();
		//Debug.Log (vertical);


	}

}