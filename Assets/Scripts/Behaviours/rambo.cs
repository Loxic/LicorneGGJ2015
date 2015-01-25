using UnityEngine;
using System.Collections;

public class rambo : MonoBehaviour {

	CharacterController controller;
	Vector3 direction;
	float vitesse;
	bool ready;
	bool quit = false;
	// Use this for initialization
	void Start () {
		controller = GetComponent("CharacterController") as CharacterController;
		direction = new Vector3(0,0,0);
	}
	
	// Update is called once per frame
	void Update () {

		direction.y --;

		if(quit)
		{
			direction.z += 100 * Time.deltaTime;
		}
		controller.Move(direction);

		if(ready)
		{
			if(Input.GetMouseButtonUp(0))
				InteractWithPlayer();
		}
	}

	// Réaction à l'interaction
	public void InteractWithPlayer()
	{
		ready = false;
		GM.displaying = true;
		Screen.lockCursor = false;
		int index = -1;
		if(GM.groupStatus == -1)
		{
			index = GM.GetIndex((int) GM.Compagnon.rambo, (int) GM.day-1, 1);
			//GetText.SetText(GM.GetIndex((int) Compagnon.rambo, 0, 1));
			print (GM.day); 
			if(index == -1)
				print ("Wrong Index founded");
			
			GetText.SetText(index);
		}
		else if(GM.groupStatus == 1)
		{
			index = GM.GetIndex((int) GM.Compagnon.rambo, (int) GM.day-1, 1);
			if(index == -1)
				print ("Wrong Index founded");
			
			//displayDialogue.GetComponent<GetText>().SetText(index);
			GetText.SetText(index);	
		}
		else
		{
			Debug.Log("Wrong GM.groupStatus to call the dialogue");
			// Lol il est tot/tard et on bosse sur un truc qui parle du temps.
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if(other.transform.tag == "Detect")
		{
			ready = true;
			if(Input.GetMouseButtonUp(0))
			{
				InteractWithPlayer();
			}
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.transform.tag == "Detect")
		{
			ready = false;
		}
	}
	
	public void callEvent(){
		Debug.Log("Ramassé !!");
	}
}
