using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (siblingManager.siblings >= 1 && Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log("u dropped the sibling off!");
				siblingManager.siblings--;
				Destroy (gameObject);
		}

	}
}
