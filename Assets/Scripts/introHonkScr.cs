using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class introHonkScr : MonoBehaviour {
	AudioSource honk;
	int honks;
	public static bool keyIn;
	public GameObject honkHand;
	public GameObject text1;
	public GameObject text2;
	void Start() {
		honk = honkHand.GetComponent<AudioSource> ();
		keyIn = false;
		text2.SetActive (false);
		text1.SetActive (true);
	 }
	// Update is called once per frame
	void Update () {

		if (keyIn) {
			text2.SetActive (true);
			text1.SetActive (false);
		}
		if (honks >= 3) {
			SceneManager.LoadScene ("testScene");
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			honk.Play ();
			if (keyIn) {
				honks++; 
			}
		}
		if (Input.GetKey(KeyCode.Space)) {
			honkHand.transform.position = new Vector3 (honkHand.transform.position.x, honkHand.transform.position.y, 0f);
		} else {
			honkHand.transform.position = new Vector3 (honkHand.transform.position.x, honkHand.transform.position.y, -10f);
		}
	}
}
