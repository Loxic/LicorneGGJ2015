using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private bool settingsUp;
	private bool pauseUp;
	private GameObject pause;
	private GameObject settings;



	void Awake () {
		//need to the object to be activate on beginning
		pause = GameObject.Find ("PauseCanvas");
		settings = GameObject.Find ("SettingsCanvas");

	}

	void Start () {
		//Deactivate the menu
		settings.SetActive (false);
		pause.SetActive (false);
		}
	
	// Update is called once per frame
	void Update () {
		//actualize booleans 
		pauseUp = pause.activeSelf;
		settingsUp = settings.activeSelf;

		//Differents behaviour
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!pauseUp && !settingsUp){
				pause.SetActive(true);
			}
		
			else if(pauseUp && !settingsUp){
				pause.SetActive(false);
			}

			else if(!pauseUp && settingsUp){
				settings.SetActive(false);
				pause.SetActive(true);
			}


		}
	
	}
}
