using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destTrigger : MonoBehaviour {
	int sibs = 0;
	public GameObject goal;
	void Start() {
		sibs = goal.GetComponentInChildren<goalTrigger>().siblings;

		}
	void OnTriggerEnter(Collider other) {
		if (sibs >= 1) {
			
				Debug.Log("u dropped the sibling off!");
				Destroy (gameObject);
				sibs--;
			
		}

	}
}
