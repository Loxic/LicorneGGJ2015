using UnityEngine;
using System.Collections;

public class BehaviourObject : MonoBehaviour {

	public int reference;
	public bool ready;

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Detect")
		{
			ready = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Detect")
		{
			ready = false;
		}
	}
	
	public void callEvent(){
		Debug.Log("Ramassé !!");
		GM.ActiveEvent(reference, this.gameObject);
	}

	void Update()
	{
		if(ready)
			if(Input.GetMouseButtonUp(0))
				callEvent();
	}
	
}
