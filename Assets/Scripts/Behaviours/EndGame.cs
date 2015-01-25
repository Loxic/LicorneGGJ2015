using UnityEngine;
using System.Collections;

public class EndGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.name == "First Person Controller"){
			if(GM.cleVerte && GM.cleRouge && GM.cleBleue && GM.cleJaune){
				//Win game
				Application.LoadLevel("WinEnd");
			}
		}
	}
}
