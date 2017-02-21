using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGenerate : MonoBehaviour {
	public GameObject roadPrefab;
	public GameObject roadContainer;
	public GameObject lastRoad;
	public int roadLength;


	// Use this for initialization
	void Start () {
		lastRoad = Instantiate (roadPrefab);

		for (int i = 0; i < roadLength; i++) {
			int genNum = Random.Range (0, 3);
			//BoxCollider[] colliders = lastRoad.GetComponents<BoxCollider>()
			GameObject nextRoad = Instantiate(roadPrefab);
			nextRoad.transform.parent = lastRoad.transform;
			if (genNum == 1) {
				nextRoad.transform.localPosition = new Vector3 (-.0125f, .28981f, -1.235f);
			} else if (genNum == 2) {
				nextRoad.transform.localPosition = new Vector3 (0.7545457f, 0.2898102f, -0.6110001f);
			}
			lastRoad = nextRoad;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 instPosition = roadPrefab.GetComponentInChildren<Transform> ();

	}
}
