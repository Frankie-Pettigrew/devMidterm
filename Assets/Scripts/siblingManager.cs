using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class siblingManager : MonoBehaviour {
	public static int siblings;
	public static int dropOffs;
	int rando;
	void Start() {
		siblings = 0;
		dropOffs = 0;
		rando = Random.Range(1, 7);
	}
	void Update() {
		if (dropOffs >= rando) {
			Debug.Log ("Level Complete");

		}
	}
}
