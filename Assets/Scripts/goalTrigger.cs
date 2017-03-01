using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {


	void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown (KeyCode.Space) && siblingManager.siblings == 0) {
			siblingManager.siblings++;
			Destroy (gameObject);
			controllerMove.text.text = "drop them off at the blue cube!";
			Debug.Log ("siblings: " + siblingManager.siblings);
		}
		
	}
}
