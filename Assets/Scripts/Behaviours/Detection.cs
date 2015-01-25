using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Detection : MonoBehaviour {

	Ray rayMouse;
	RaycastHit hit;
	GameObject display;

	void Awake ()
	{
		display = GameObject.Find("DisplayCanvas");
	}

	// Use this for initialization
	void Start () {
	
		Screen.lockCursor = true;
	}
	
	// Update is called once per frame
	void Update () {
	
		detectionObjet();

		if(!GM.displaying)
		{
			Screen.lockCursor = true;
		}
		else
		{
			Screen.lockCursor = false;
		}
	}


	void detectionObjet(){

	
		if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit)){//si la souris rencontre l'objet "hit" on fait quelqu chose
			if(hit.collider.transform.tag == "PickUp"){
				Debug.Log("Je te vois !");
				if(Input.GetMouseButton(0)){
					pickUp(hit.collider.gameObject);
				}
			}
			else if (hit.collider.transform.tag == "Hover")
			{
				if(hit.collider.gameObject.GetComponent<BehaviourObject>().reference == 1)
				{
					display.GetComponent<Display>().DisplayWood(GM.firewood);
				}
				if(hit.collider.gameObject.GetComponent<BehaviourObject>().reference == 2)
				{
					display.GetComponent<Display>().DisplayFood(GM.food);
				}
			}
			else if (hit.collider.transform.tag == "Npc")
			{
				if(Input.GetMouseButtonUp(0))
				{
					hit.collider.gameObject.SendMessage("InteractWithPlayer");
				}
			}
		}
		
	}

	void pickUp(GameObject objet){
				objet.GetComponent<BehaviourObject> ().callEvent ();
		}
}

