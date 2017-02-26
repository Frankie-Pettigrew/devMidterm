using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {
	
	public int siblings = 0;

	void OnTriggerEnter(Collider other) {
		
			siblings++;
			Destroy (gameObject);
			Debug.Log ("siblings: " + siblings);
		
	}
}
