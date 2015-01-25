using UnityEngine;
using System.Collections;

public class EventScript : MonoBehaviour {


	public int reference = -1;
	public float depart = -1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getDepart()
	{
		return depart;
	}

	public int getReference()
	{
		return reference;
	}
}
