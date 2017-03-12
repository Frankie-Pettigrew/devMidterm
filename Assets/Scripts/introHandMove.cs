using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introHandMove : MonoBehaviour {

	public float moveSpeed;
	float yPos;
	float xPos;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (0, -2, 4);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.W)) {
			if (yPos <= 5 && yPos >= -4) {
				yPos += moveSpeed * Time.deltaTime;
			}
		}
		if (Input.GetKey (KeyCode.S)) {
			if (yPos <= 5 && yPos >= -4) {
				yPos -= moveSpeed * Time.deltaTime;
			}
		}
		if (Input.GetKey (KeyCode.A)) {
			if (xPos <= 10 && xPos >= -10) {
				xPos -= moveSpeed * Time.deltaTime;
			}

		}
		if (Input.GetKey (KeyCode.D)) {
			if (xPos <= 10 && xPos >= -10) {
				xPos += moveSpeed * Time.deltaTime;
			}
		}

		if (yPos > 5) {
			yPos = 5;
		}
		if (yPos < -4) {
			yPos = -4;
		}

		if (xPos > 10) {
			xPos = 10;
		}
		if (xPos < -10) {
			xPos = -10;
		}

		transform.position = new Vector3 (xPos, yPos, transform.position.z);
	}
}
