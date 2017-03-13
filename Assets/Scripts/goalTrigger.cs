using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {
	public GameObject text1;

	void OnTriggerStay(Collider other) {
		if (other.tag == "Player") {
			text1.SetActive (true);
		}
		if (Input.GetKeyDown (KeyCode.Space) && siblingManager.siblings == 0 && other.tag == "Player") {
			siblingManager.siblings++;
			Destroy (gameObject);
			Debug.Log ("siblings: " + siblingManager.siblings);
			text1.SetActive (false);
		}
		
	}
}
