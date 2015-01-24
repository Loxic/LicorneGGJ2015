using UnityEngine;
using System.Collections;

/*

				ATTACHER AU PLAYER
*/


public class Detection : MonoBehaviour {

	Ray rayMouse;
	RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
		detectionObjet();
	}


	void detectionObjet(){
		
		rayMouse = camera.ScreenPointToRay (Input.mousePosition);
	
		if(Physics.Raycast(rayMouse, out hit)){//si la souris rencontre l'objet "hit" on fait quelqu chose
			if(hit.collider.transform.tag == "pickUp"){
				if(Input.GetMouseButton(0)){	
					pickUp(hit.collider.gameObject);
				}
			}
		}
		
	}

	void pickUp(GameObject objet){
				objet.GetComponent<BehaviourObject> ().callEvent ();
		}
}

