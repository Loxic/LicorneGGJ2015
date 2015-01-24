using UnityEngine;
using System.Collections;


/*

					CLASSE DES OBJETS A RAMASSER
*/
public class BehaviourObject : MonoBehaviour {

	public int reference;
	
	public void callEvent(){
		GM.ActiveEvent(reference, this.gameObject);
	}
}
