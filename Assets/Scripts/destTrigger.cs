using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destTrigger : MonoBehaviour {
	int sibs;
	GameObject playerCar;
	void Start() {
		playerCar = GameObject.FindGameObjectWithTag ("Player");
		Debug.Log (playerCar.name);

		}
	void OnTriggerEnter(Collider other) {
		sibs = playerCar.GetComponent<siblingManager> ().siblings;

		if (sibs >= 1) {
			
				Debug.Log("u dropped the sibling off!");
				Destroy (gameObject);
				sibs--;
			
		}

	}
}
