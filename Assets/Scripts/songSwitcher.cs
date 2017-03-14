using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class songSwitcher : MonoBehaviour {
	AudioSource source;
	public AudioClip pomPom;
	public AudioClip kyleDuke;
	public AudioClip tallBoi;
	public AudioClip mothernight;
	public AudioClip jackenton;
	int random;
	// Use this for initialization
	void Start () {
		source = gameObject.GetComponent<AudioSource> ();
		random = Random.Range (1, 4);
		if (random < 1) {
			source.clip = pomPom;
		} else if (random == 1) {
			source.clip = jackenton;
		}
		else if (random <= 2) {
			source.clip = kyleDuke;
		} else if (random <= 3) {
			source.clip = tallBoi;
		} else if (random == 4) {
			source.clip = mothernight;
		}
		source.Play ();
			
	}

	void Update() {
		if (Input.GetKeyDown (KeyCode.E)) {
			random++;
			if (random >= 5) {
				random = 4;
			}
			if (random <= 0) {
				random = 0;
			}
			if (random == 0) {
				source.clip = pomPom;
			} else if (random == 1) {
				source.clip = jackenton;
			}
			else if (random <= 2) {
				source.clip = kyleDuke;
			} else if (random <= 3) {
				source.clip = tallBoi;
			} else if (random == 4) {
				source.clip = mothernight;
			}
			source.Play ();
		} 
		if (Input.GetKeyDown (KeyCode.Q)) {
			random--;
			if (random >= 5) {
				random = 4;
			}
			if (random <= 0) {
				random = 0;
			}
			if (random == 0) {
				source.clip = pomPom;
			} else if (random == 1) {
				source.clip = jackenton;
			}
			else if (random <= 2) {
				source.clip = kyleDuke;
			} else if (random <= 3) {
				source.clip = tallBoi;
			} else if (random == 4) {
				source.clip = mothernight;
			}
			source.Play ();
		} 





	}


	

}
