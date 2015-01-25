using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_BadGuy : MonoBehaviour {

	int amountFirewood = 0, amountFood = 0, maxFood = 10, maxFireWood = 60;
	//static public List<int> dialogues;
	int sanity = 100;
	GameObject displayDialogue;


	void Awake() 
	{
		displayDialogue = GameObject.Find("DialogueText");
		
	}
	// Use this for initialization
	void Start () {

		/*int i;
		for(i = 25;i<54; i++)
		{
			dialogues.Add(i);
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Réaction à l'interaction
	void InteractWithPlayer()
	{
		int index = -1;
		if(GM.groupStatus == -1)
		{
			index = GM.GetIndex((int) GM.Compagnon.badGuy, (int) GM.day, 1);
			//GetText.SetText(GM.GetIndex((int) Compagnon.rambo, 0, 1));
			if(index == -1)
				print ("Wrong Index founded");
			
			GetText.SetText(index);
		}
		else if(GM.groupStatus == 1)
		{
			index = GM.GetIndex((int) GM.Compagnon.badGuy, (int) GM.day, 1);
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
	
	
	// Ces fonctions sont appelées par le trigger de sortie de map
	void SentToMissionFood(int difficulty)
	{
		switch(difficulty)
		{
		case 1:
			GM.food += Random.Range(1, 3);
			break;
		case 2:
			GM.food += Random.Range(4, 5);
			if(Random.Range(0, 100) >= 30 )
			{
				Die();
			}
			break;
		case 3:
			GM.food += Random.Range(5, 10);
			if(Random.Range(0, 100) >= 60 )
			{
				Die();
			}
			break;
		}
	}
	
	void SentToMissionWood(int difficulty)
	{
		switch(difficulty)
		{
		case 1:
			GM.firewood += Random.Range(10, 15);
			break;
		case 2:
			GM.firewood += Random.Range(20, 30);
			if(Random.Range(0, 100) >= 30 )
			{
				Die();
			}
			break;
		case 3:
			GM.firewood += Random.Range(40, 60);
			if(Random.Range(0, 100) >= 60 )
			{
				Die();
			}
			break;
		}
	}
	
	
	
	
	
	
	
	
	void Die()
	{
		GM.ActiveEvent(-99, this.gameObject);
	}
	
	void TimeOfMADNESS ()
	{
		GM.ActiveEvent(666, this.gameObject);
	}
}
