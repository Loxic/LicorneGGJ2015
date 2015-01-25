using UnityEngine;
using System.Collections;

public class SpawnForest : MonoBehaviour {

	int nbPoints = 15;

	// Use this for initialization
	void Start () {

		int i;
		for(i=0; i <15; i++)
		{
			Transform balise = GameObject.Find(i.ToString()).transform;
			if(Random.Range(1, 3) > 1)
			{
				Instantiate((GameObject)Resources.Load("Prefabs/stick"), balise.position, balise.rotation);
			}
			else
			{
				Instantiate((GameObject)Resources.Load("Prefabs/can"), balise.position, balise.rotation);
			}
		}

		Screen.lockCursor = true;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
