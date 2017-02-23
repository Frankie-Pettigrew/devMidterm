using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGenerate : MonoBehaviour {
	public GameObject roadPrefab;
	public GameObject roadContainer;
	public GameObject lastRoad;
	public GameObject goalPrefab;
	public GameObject destPrefab;
	public int roadLength;
	bool turnRight;
	bool turnLeft;
	bool goStraight;
	bool isRight;
	bool isLeft;
	bool isStraight = true;
	//Vector3 lastRotation = new Vector3 (0, 0, 0);


	// Use this for initialization
	void Start () {
		//cache lastRoad and create first road
		lastRoad = Instantiate (roadPrefab);
		//lastRoad.transform.position = new Vector3 (0, 0, 0);

		for (int i = 0; i < roadLength; i++) {
			//random number determines which turn to make
			int genNum = Random.Range (0, 3);
			//BoxCollider[] colliders = lastRoad.GetComponents<BoxCollider>()
			GameObject nextRoad = Instantiate(roadPrefab);
			goalGenerate (goalPrefab, i, nextRoad, 3);
			goalGenerate (destPrefab, i, nextRoad, 5);
			//Straight
			if (genNum == 1) {
				goStraight = true;
				turnLeft = false;
				turnRight = false;
				fixRotation(nextRoad);
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (0, 0, -1.235f);

			} //Left
			else if (genNum == 2) {
				goStraight = false;
				turnLeft = true;
				turnRight = false;
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 270f, 0f);
				fixRotation(nextRoad);
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (3.867048f, 0, -0.6110001f);

			} //Right
			else {
				goStraight = false;
				turnLeft = false;
				turnRight = true;
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 90f, 0f);
				fixRotation(nextRoad);
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (-3.875433f, 0, -.6126667f);
			}
			//lastRotation = nextRoad.transform.localEulerAngles;
			lastRoad = nextRoad;
			Debug.Log(i + ". " + isStraight + isRight + isLeft);
		}
	}
		

	void fixRotation(GameObject nextRoad) {
		if (turnRight) {
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				isStraight = true;
				isLeft = false;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				isStraight = true;
				isRight = false;
			} else if(isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				isStraight = false;
				isRight = true; 
			}
		} else if (turnLeft) {
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				isStraight = true;
				isLeft = false;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				isStraight = true;
				isRight = false;
			} else if (isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				isStraight = false;
				isLeft = true;
			}

		} else if(goStraight) {
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				isLeft = true;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				isRight = true;
			} else if (isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
				isStraight = true;
			}
		}

	}

	void goalGenerate(GameObject goal, int i, GameObject road, int dest) {
		if (i == Mathf.RoundToInt (dest)) {
			GameObject fab = Instantiate (goal);
			fab.transform.parent = road.transform;
			fab.transform.localPosition = new Vector3 (0f, .8f, 0f);
			Debug.Log (goal.name + " generated");
		}


	}
}
