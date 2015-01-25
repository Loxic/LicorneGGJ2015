using UnityEngine;
using System.Collections;

public class SpawnCave : MonoBehaviour {
	
	int nbPoints = 9;
	
	// Use this for initialization
	void Start () {
		
		int i;
		for(i=1; i <nbPoints; i++)
		{
			int random = Random.Range(1,3);
			Transform balise = GameObject.Find(i.ToString()).transform;
			if(random == 1)
			{
				Instantiate((GameObject)Resources.Load("Prefabs/stick"), balise.position, balise.rotation);
			}
			else if(random == 2)
			{
				Instantiate((GameObject)Resources.Load("Prefabs/can"), balise.position, balise.rotation);
			}
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
