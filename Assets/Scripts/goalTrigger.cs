using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {
	
	GameObject playerCar;
	int sibs;
	void Start() {
		sibs = 0;
		playerCar = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter(Collider other) {
		playerCar.GetComponent<siblingManager> ().siblings = sibs;
		sibs++;
			Destroy (gameObject);
			Debug.Log ("siblings: " + sibs);
		
	}
}
