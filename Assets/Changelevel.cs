using UnityEngine;
using System.Collections;

public class Changelevel : MonoBehaviour {

	GameObject Go;

	void Start(){
		Go = new GameObject();
	}

	public void LoadForest(){
		GM.ActiveEvent(-1,Go);
	}

	public void LoadRiver(){
		GM.ActiveEvent(0,Go);
	}

}
