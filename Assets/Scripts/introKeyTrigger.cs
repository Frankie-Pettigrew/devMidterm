using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introKeyTrigger : MonoBehaviour {
	public Sprite hand;

	void OnTriggerStay(Collider other) {
		Destroy (gameObject.GetComponentInChildren<SpriteRenderer> ());
		other.GetComponentInChildren<SpriteRenderer> ().sprite = hand;
		other.transform.eulerAngles = new Vector3 (other.transform.eulerAngles.x, 180, other.transform.eulerAngles.z);
		other.transform.localScale = new Vector3 (5f, 5f, 5f);
		SceneManager.LoadScene ("introHonk");
	}
}
