using UnityEngine;
using System.Collections;

public class FinalRunSound : MonoBehaviour {

	AudioSource [] sounds;
	float waitTime;
	float beenWaiting;

	// Use this for initialization
	void Start () {
		waitTime = 2;
		beenWaiting = 0;
		sounds = GetComponents<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		beenWaiting += Time.deltaTime;
		if(beenWaiting >= waitTime){
			GM.engage = true;
			sounds[Random.Range(0,1)].Play();
			beenWaiting = 0;
			waitTime = Random.Range(2f,10f);
		}
	}
}
