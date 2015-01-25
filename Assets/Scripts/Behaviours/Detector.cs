using UnityEngine;
using System.Collections;

public class Detector : MonoBehaviour {

	GameObject display;

	void Awake ()
	{
		display = GameObject.Find("DisplayCanvas");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		if(other.transform.tag == "PickUp")
		{
			if(Input.GetMouseButtonUp(0))
				other.SendMessage("callEvent");
		}
		else if(other.transform.tag == "Hover")
		{
			if(other.gameObject.GetComponent<BehaviourObject>().reference == 1)
			{
				display.GetComponent<Display>().DisplayWood(GM.firewood);
			}
			else if(other.gameObject.GetComponent<BehaviourObject>().reference == 2)
			{
				display.GetComponent<Display>().DisplayFood(GM.food);
			}
		}
		else if(other.transform.tag == "Rambo")
		{


			if(Input.GetMouseButtonUp(0))
			{
				GM.rambo.GetComponent<rambo>().InteractWithPlayer();
			}
		}
	}
}
