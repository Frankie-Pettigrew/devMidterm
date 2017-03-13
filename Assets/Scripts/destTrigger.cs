using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class destTrigger : MonoBehaviour {
	public GameObject text1;
	public GameObject text2;
	void Start() {
		text1.SetActive(true);
		text2.SetActive(false);
	}

	void OnTriggerStay(Collider other) {
		
		if (siblingManager.siblings >= 1 && Input.GetKeyDown(KeyCode.Space) && other.tag == "Player") {
				Debug.Log("u dropped the sibling off!");
				siblingManager.siblings--;
				siblingManager.dropOffs++;
				Destroy (gameObject);
				text1.SetActive(false);
				text2.SetActive(true);
				//SceneManager.LoadScene ("testScene");
		}

	}
}
