using UnityEngine;
using System.Collections;

public class FootSteps : MonoBehaviour {

	float tempo;
	float lastTime;
	bool isMoving;
	Vector3 lastPos;
	AudioSource [] stepsSound;

	int baseIndex;
	int lastPlayed;


	// Use this for initialization
	void Start () {
		tempo = 0.5f;
		baseIndex = 2;
		lastTime = 0;
		lastPlayed = 2;
		isMoving = false;
		stepsSound = GetComponents<AudioSource>();
		lastPos = GameObject.FindWithTag ("MainCamera").camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 currentPos = GameObject.FindWithTag ("MainCamera").camera.transform.position;
		if (lastPos == currentPos) {
			isMoving = false;
		} else {
			isMoving = true;
		}
		if (isMoving) {
			playStep ();
		}
		lastPos = currentPos;
	}

	void playStep(){
		lastTime += Time.deltaTime;
		if (lastTime >= tempo) {
			lastPlayed += Random.Range(1,2);
			lastPlayed %= 3;
			stepsSound[lastPlayed+baseIndex].Play();
			lastTime = 0;
		}
	}
}
