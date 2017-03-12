using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introKeyTrigger : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log ("key grabbo-d!");
		}
	}
}
