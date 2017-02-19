using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class vectorTest : MonoBehaviour {
	public GameObject player;
	public GameObject sodaCan;
	Vector3 playerPos;
	Vector3 sodaCanPos;
	Text myText; 
	bool foundCan;

	// Use this for initialization
	void Start () {
	//	Debug.Log (Vector3.Distance (playerPos, sodaCanPos));
		myText = GetComponent<Text> ();
		sodaCanPos = sodaCan.GetComponent<Transform> ().position;
		foundCan = false;
	}
	
	// Update is called once per frame
	void Update () {
		playerPos = player.GetComponent<Transform> ().position;

		if (Vector3.Distance (playerPos, sodaCanPos) > 7f && !foundCan) {
			myText.text = "pick up the sibling!";

		}  else if(Vector3.Distance(playerPos, sodaCanPos) < 7f) {
			foundCan = true;
			Debug.Log( "u got da sibling");

		} 
			


	}
}
