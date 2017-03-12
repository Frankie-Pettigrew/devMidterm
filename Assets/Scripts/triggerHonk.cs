using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerHonk : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		other.gameObject.transform.position = gameObject.transform.position;
		other.transform.SetParent(null);
		if (Input.GetKey (KeyCode.D)) {
			Debug.Log ("key turned");
		}
	}
}