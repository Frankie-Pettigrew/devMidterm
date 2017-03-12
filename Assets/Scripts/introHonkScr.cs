using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class introHonkScr : MonoBehaviour {

	public GameObject honkHand;

	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.Space)) {
			honkHand.transform.position = new Vector3 (honkHand.transform.position.x, honkHand.transform.position.y, 5f);
		} else {
			honkHand.transform.position = new Vector3 (honkHand.transform.position.x, honkHand.transform.position.y, -10f);
		}
	}
}
