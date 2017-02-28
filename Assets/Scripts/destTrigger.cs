using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destTrigger : MonoBehaviour {

	void OnTriggerStay(Collider other) {
		if (siblingManager.siblings >= 1 && Input.GetKeyDown(KeyCode.Space)) {
				Debug.Log("u dropped the sibling off!");
				siblingManager.siblings--;
				controllerMove.text.text = "You picked up the sibling!";
				Destroy (gameObject);
		}

	}
}
