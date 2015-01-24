using UnityEngine;
using System.Collections;

public class BehaviourObject : MonoBehaviour {

	public int reference;
	
	public void callEvent(){
		GM.ActiveEvent(reference, this.gameObject);
	}
}
