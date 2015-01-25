using UnityEngine;
using System.Collections;

public class Rift : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		other.SendMessage("Die");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
