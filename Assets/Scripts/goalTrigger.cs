using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class goalTrigger : MonoBehaviour {
	public Text text;
	public int siblings;
	void OnTriggerEnter(Collider other) {
		if(siblings > 1) {
			siblings--;
			text.text = "u dropped the sibling off!";
			Destroy (gameObject);
		} else{
		//if (other.tag == "Player") {
			siblings++;
			
			Destroy (gameObject);
			Debug.Log("siblings: " + siblings);
		//}
		}
	}
}
