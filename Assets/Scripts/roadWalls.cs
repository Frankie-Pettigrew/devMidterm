using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadWalls : MonoBehaviour {
	public GameObject wall;
	BoxCollider coll;
	public SpriteRenderer[] tree;
	void Awake() {
		coll = wall.GetComponent<BoxCollider> ();
		coll.isTrigger = false;
		tree = wall.GetComponentsInChildren<SpriteRenderer> ();
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log ("TriggerDone");
		if (other.tag == "roads") {
			coll.isTrigger = true;
			tree [1].sprite = null;
			tree [2].sprite = null;
			this.transform.gameObject.SetActive (false);
		} 
	}

}
