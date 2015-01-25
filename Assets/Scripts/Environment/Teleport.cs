using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public string destination;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel(destination);
	}
}
