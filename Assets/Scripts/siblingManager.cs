using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class siblingManager : MonoBehaviour {
	public static int siblings;
	public static int dropOffs;
	public GameObject text1;
	public GameObject text2;
	void Start() {
		siblings = 0;
		dropOffs = 0;
	}
	void Update() {
		if (siblings < 1) {
			text1.SetActive (true);
			text2.SetActive (false);
		} else {
			text1.SetActive (false);
			text2.SetActive (true);
		}
		if (dropOffs >= 3) {
			SceneManager.LoadScene ("titleScreen");
		}
	}
}
