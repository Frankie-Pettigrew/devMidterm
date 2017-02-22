using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGenerate : MonoBehaviour {
	public GameObject roadPrefab;
	public GameObject roadContainer;
	public GameObject lastRoad;
	public int roadLength;
	bool turnRight;
	bool turnLeft;
	bool goStraight;
	bool isRight;
	bool isLeft;
	bool isStraight;
	Vector3 lastRotation = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Start () {
		lastRoad = Instantiate (roadPrefab);

		for (int i = 0; i < roadLength; i++) {
			int genNum = Random.Range (0, 3);
			//BoxCollider[] colliders = lastRoad.GetComponents<BoxCollider>()
			GameObject nextRoad = Instantiate(roadPrefab);
			if (genNum == 1) {
				goStraight = true;
				turnLeft = false;
				turnRight = false;
				fixRotation();
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (-.0125f, 0, -1.235f);
			} else if (genNum == 2) {
				goStraight = false;
				turnLeft = true;
				turnRight = false;
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 270f, 0f);
				fixRotation();
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (3.867048f, 0, -0.6110001f);
			} else {
				goStraight = false;
				turnLeft = false;
				turnRight = true;
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 90f, 0f);
				fixRotation();
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (-3.875433f, 0, -.6126667f);
			}
			lastRotation = nextRoad.transform.localEulerAngles;
			lastRoad = nextRoad;
		}
	}
		
	// Update is called once per frame
	void Update () {
		//Vector3 instPosition = roadPrefab.GetComponentInChildren<Transform> ();

	}

	void fixRotation() {
		if (turnRight) {
			if (isLeft) {

			} else if (isRight) {

			} else if(isStraight) {

			}
		} else if (turnLeft) {
			if (isLeft) {

			} else if (isRight) {

			} else if (isStraight) {

			}

		} else if(goStraight) {
			if (isLeft) {
				
			} else if (isRight) {

			} else if (isStraight) {

			}
		}

	}
	void fixPosition() {
		if (turnRight) {

		} else if (turnLeft) {

		} else if (goStraight) {

		}
	}
}
