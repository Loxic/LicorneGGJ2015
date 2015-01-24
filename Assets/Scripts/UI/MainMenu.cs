using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {


	public void quit() {
		Application.Quit ();
		
	}

	public void StartGame(){
		Application.LoadLevel ("Pause Menu Test");
		
	}

	public void ReturnMainMenu(){
		Application.LoadLevel ("Main Menu");

		}

}
