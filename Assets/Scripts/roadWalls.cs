using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadWalls : MonoBehaviour {
	public GameObject wall;
	BoxCollider coll;
	void Awake() {
		coll = wall.GetComponent<BoxCollider> ();
		coll.isTrigger = false;
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("TriggerDone");
		if (other.tag == "roads") {
			coll.isTrigger = true;
			this.transform.gameObject.SetActive (false);
		} 
	}

}
