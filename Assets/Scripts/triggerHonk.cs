using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerHonk : MonoBehaviour {
	public Sprite keyhole;
	public Sprite hand;
	void OnTriggerEnter(Collider other) {
		
		gameObject.GetComponentInChildren<SpriteRenderer> ().sprite = keyhole;
		other.GetComponentInChildren<SpriteRenderer> ().sprite = hand;
		other.transform.eulerAngles = new Vector3 (other.transform.eulerAngles.x, 180, other.transform.eulerAngles.z);
		other.transform.position = new Vector3 (other.transform.position.x, other.transform.position.y, 0);
		introHonkScr.keyIn = true;
	}
}