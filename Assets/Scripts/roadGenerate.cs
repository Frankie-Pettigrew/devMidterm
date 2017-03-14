using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadGenerate : MonoBehaviour {
	public GameObject roadPrefab;
	public GameObject roadContainer;
	public GameObject lastRoad;
	public GameObject treeFab;
	public GameObject goalPrefab;
	public GameObject destPrefab;
	public Sprite stopSign;
	SpriteRenderer stopSignRender;
	public int roadLength;
	bool turnRight;
	bool turnLeft;
	bool goStraight;
	bool isRight;
	bool isLeft;
	bool isStraight = true;
	bool isBack;
	int doubledRight;
	int doubledLeft;
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
			goalGenerate (goalPrefab, i, nextRoad, 13);
			goalGenerate (destPrefab, i, nextRoad, 15);
			goalGenerate (goalPrefab, i, nextRoad, 23);
			goalGenerate (destPrefab, i, nextRoad, 25);

			stopSignRender = nextRoad.GetComponentInChildren<SpriteRenderer> ();

			if (i == 5 || i == 10 || i == 15 || i == 20 || i == 25 || i == 30) {
				stopSignRender.sprite = stopSign;
			} else {
				stopSignRender.sprite = null;
			}
			//Straight
			if (genNum == 1) {
				goStraight = true;
				turnLeft = false;
				turnRight = false;
				fixRotation(nextRoad, lastRoad);
				nextRoad.transform.parent = lastRoad.transform;
				nextRoad.transform.localPosition = new Vector3 (0, ((-1-i)/1000f), -1.235f);
				nextRoad.transform.parent = null;


			} //Left
			else if (genNum == 2) {
				if (doubledLeft <= 1) {
					goStraight = true;
					turnLeft = false;
					turnRight = false;
					doubledLeft++;
					fixRotation(nextRoad, lastRoad);
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (0, ((-1-i)/1000f), -1.235f);
					nextRoad.transform.parent = null;
					if(doubledLeft == 3) {
						doubledLeft = 0;
						}
				} else if (isLeft) {
					goStraight = false;
					turnLeft = true;
					turnRight = false;
					doubledLeft++;
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (3.82f, ((-1-i)/ 1000f), -0.6110001f);
					nextRoad.transform.parent = null;

				} else {
					goStraight = false;
					turnLeft = true;
					turnRight = false;
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (3.82f, ((-1-i)/ 1000f), -0.6110001f);
					nextRoad.transform.parent = null;
				}
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 270f, 0f);
				fixRotation(nextRoad, lastRoad);

			} //Right
			else {
				if (doubledRight <= 1) {
					goStraight = true;
					turnLeft = false;
					turnRight = false;
					doubledRight++;
					fixRotation(nextRoad, lastRoad);
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (0, (-i/1000f), -1.235f);
					nextRoad.transform.parent = null;
					if (doubledRight == 3) {
						doubledRight = 0;
					}
				} else if (isRight) {
					goStraight = false;
					turnLeft = false;
					turnRight = true;
					doubledRight++;
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (-3.82f, (-i/1000f),-0.6110001f);
					nextRoad.transform.parent = null;

				} else {
					goStraight = false;
					turnLeft = false;
					turnRight = true;
					nextRoad.transform.parent = lastRoad.transform;
					nextRoad.transform.localPosition = new Vector3 (-3.82f, (-i/1000f), -0.6110001f);
					nextRoad.transform.parent = null;
				}
				//nextRoad.transform.localEulerAngles = lastRotation + new Vector3 (0f, 90f, 0f);
				fixRotation(nextRoad, lastRoad);

			}
			//lastRotation = nextRoad.transform.localEulerAngles;
			lastRoad = nextRoad;
			Debug.Log(i + ". " + isStraight + isRight + isLeft);
		}
	}
		

	void fixRotation(GameObject nextRoad, GameObject lastRoad) {
		//BoxCollider[] boxColliders;
		//boxColliders = lastRoad.GetComponentsInChildren<BoxCollider> ();

		if (turnRight) {
			/*boxColliders [2].isTrigger = true;
			boxColliders [1].isTrigger = false;
			boxColliders [0].isTrigger = false; */
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
				isStraight = true;
				isLeft = false;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
				isBack = true;
				isRight = false;
			} else if (isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				isStraight = false;
				isRight = true; 
			} else if (isBack) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				isLeft = true;
				isBack = false;
			}
		} else if (turnLeft) {
			/*	boxColliders [2].isTrigger = false;
			boxColliders [1].isTrigger = true;
			boxColliders [0].isTrigger = false;*/
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 180f, 0f);
				isBack = true;
				isLeft = false;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
				isStraight = true;
				isRight = false;
			} else if (isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				isStraight = false;
				isLeft = true;
			} else if (isBack) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				isBack = false;
				isRight = true;
			}

		} else if (goStraight) {
			/*boxColliders [2].isTrigger = false;
			boxColliders [1].isTrigger = false;
			boxColliders [0].isTrigger = true;*/
			if (isLeft) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -90f, 0f);
				isLeft = true;
			} else if (isRight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 90f, 0f);
				isRight = true;
			} else if (isStraight) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, 0f, 0f);
				isStraight = true;
			} else if (isBack) {
				nextRoad.transform.localEulerAngles = new Vector3 (0f, -180f, 0f);
				isBack = true;
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
