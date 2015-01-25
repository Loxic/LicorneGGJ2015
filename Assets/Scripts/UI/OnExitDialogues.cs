using UnityEngine;
using System.Collections;

public class OnExitDialogues : MonoBehaviour {

	public void QuitGUI(){
		GM.displaying = false;
		Screen.lockCursor = true;
		Application.LoadLevel("foret");
	}


}
