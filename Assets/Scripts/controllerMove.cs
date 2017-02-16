using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerMove : MonoBehaviour {
	CharacterController playerCon;
	// Use this for initialization
	void Start () {
		playerCon = GetComponent<CharacterController> (); // save reference to our component
	}
	
	// Update is called once per frame
	void Update () {
		//1. grab input from input devices
		float horizontal = Input.GetAxis ("Horizontal"); //left and right movement
		float vertical = Input.GetAxis ("Vertical"); // up and down movement
		float jump = Input.GetAxis("Jump");

		//2. plug your values into the character controller
		playerCon.Move(transform.forward * Time.deltaTime * vertical * 5f); // move along forward facing 
		transform.Rotate( 0f, horizontal * Time.deltaTime * 90f, 0f);

		//3. let's add gravity
		playerCon.Move(Physics.gravity * 0.05f);

		//4. let us press SPACE to jump
		if (Input.GetKeyDown(KeyCode.Space) && playerCon.isGrounded == true) {
			playerCon.Move( new Vector3(0f, 3f, 0f));

		}

	}
}