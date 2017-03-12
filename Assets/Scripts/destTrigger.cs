using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destTrigger : MonoBehaviour {

	void Start() {
		controllerMove.text.text = "Pick up the sibling at the red cube!";

	}

	void OnTriggerStay(Collider other) {
		
		if (siblingManager.siblings >= 1 && Input.GetKeyDown(KeyCode.Space) && other.tag == "Player") {
				Debug.Log("u dropped the sibling off!");
				siblingManager.siblings--;
				controllerMove.text.text = "You dropped off the sibling! Find the next one!";
				siblingManager.dropOffs++;
				Destroy (gameObject);
				//SceneManager.LoadScene ("testScene");
		}

	}
}
