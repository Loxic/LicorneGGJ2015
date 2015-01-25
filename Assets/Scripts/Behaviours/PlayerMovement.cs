using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Vector3 direction;
	public float speedLeft, speedFwd;
	CharacterController controller;

	// Use this for initialization
	void Start () {
	
		controller = GetComponent("CharacterController") as CharacterController;

	}
	
	// Update is called once per frame
	void Update () {
	
		if(!GM.displaying)
		{
			Screen.lockCursor = true;
			transform.Rotate(0, Input.GetAxis("Mouse X"), 0);
			//speedFwd = speedFwd*2;
			direction = new Vector3(Input.GetAxis("Horizontal") * Time.deltaTime * speedLeft, -0.5f, Input.GetAxis("Vertical") * Time.deltaTime * speedFwd);
			direction = transform.TransformDirection(direction);
			controller.Move(direction);
		}
	}
}
