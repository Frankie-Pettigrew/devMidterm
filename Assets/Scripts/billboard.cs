using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billboard : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if (this.tag == "dest") {
			transform.localEulerAngles = new Vector3 (transform.localEulerAngles.x, 180, transform.localEulerAngles.z);
			transform.LookAt (Camera.main.transform.position, Vector3.forward);

		}
		transform.LookAt (Camera.main.transform.position, Vector3.up);
	}
}
