using UnityEngine;
using System.Collections;

public class BossHitbox : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){//Trigger/Collision/contact/stay
		if(other.name == "First Person Controller"){
			Debug.Log("You got had");
			GM.GameOver("Death by slowness");
		}
	}
}
