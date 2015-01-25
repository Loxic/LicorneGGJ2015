using UnityEngine;
using System.Collections;

public class HeartBeat : MonoBehaviour {

	Vector3 position;
	Vector3 limite ;
	AudioSource[] sounds;
	AudioSource heart;
	float distanceAvant;

	double startingPitch = 0.4;
	double finalPitch = 2.4;
		
	// Use this for initialization
	void Start () {

		sounds = GetComponents<AudioSource> ();
		heart = sounds[1];
		heart.pitch = (float)startingPitch;
		limite = GameObject.FindWithTag ("Limite").transform.position;
		distanceAvant = 10;
			
		}
		
		// Update is called once per frame
	void Update () {

		heartBeat ();

	}
	
	void heartBeat(){

		position = GameObject.FindWithTag ("MainCamera"). camera.transform.position;
		float distance = Vector3.Distance(position, limite);
	
		if(distance <= 10 && heart.pitch <= finalPitch){ //Plus on e rapproche de la limite

			if(!heart.isPlaying){
				heart.Play();
			}
			if(distance != distanceAvant){
				heart.pitch += Time.deltaTime * (distanceAvant - distance)*5;
			}
			distanceAvant = distance;
		} else {
			heart.Stop();
		}
		if(heart.pitch > finalPitch){
			heart.Stop();
			return ; //le monsieur meurt
		}

	}

	void OnTriggerEnter(Collider  col){
		if(col.tag == "Limite"){
			heart.Stop();
		}
  }


}