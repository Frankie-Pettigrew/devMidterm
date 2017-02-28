using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {


	void OnTriggerStay(Collider other) {
		if (Input.GetKeyDown (KeyCode.Space)) {
			siblingManager.siblings++;
			Destroy (gameObject);
			Debug.Log ("siblings: " + siblingManager.siblings);
		}
		
	}
}
