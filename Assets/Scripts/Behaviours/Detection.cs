using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

	Ray rayMouse;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;	
	}
	
	// Update is called once per frame
	void Update () {
	
		detectionObjet();
		if(GM.choosing == false)
		{
			Screen.lockCursor = true;
		}
		else
		{
			Screen.lockCursor = false;
		}
	}


	void detectionObjet(){


		rayMouse = camera.ScreenPointToRay (Input.mousePosition);
	
		if(Physics.Raycast(this.transform.position, this.transform.forward,  out hit, 1.85f)){//si la souris rencontre l'objet "hit" on fait quelqu chose
			if(hit.collider.transform.tag == "PickUp"){
				if(Input.GetMouseButtonUp(0)){
					pickUp(hit.collider.gameObject);
				}
			}
		}
		
	}

	void pickUp(GameObject objet){
				objet.GetComponent<BehaviourObject> ().callEvent ();
		}
}

