using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	// Ressources
	static int firewood = 0, food = 0, keys = 0; // measure in units

	// Time system variables
	static float day = 0, hour = 0;
	static string currentState = "day";
	static bool stopBigBen = false;
	static int countDownBeforeDoom = -1;

	// event material
	static List<GameObject> gOList;
	bool win = false;

	void Start () {
		StartCoroutine(BigBen());
		gOList = new List<GameObject>();

		// filling gOList
		GameObject[] byTags = GameObject.FindGameObjectsWithTag("Timed");
		int i;
		for(i=0;i<byTags.Length; i++)
		{
			gOList.Add(byTags[i]);
		}
	}


	void Update () {
	
	}



	// Scenes management

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GameOver(string statement)
	{
		
	}

	public void GoToWoods(string direction)
	{
		if(direction == "north")
			Application.LoadLevel("NorthScene");
		else if(direction == "east")
			Application.LoadLevel("EastScene");
		else if(direction =="south")
			Application.LoadLevel("SouthScene");
		else if(direction == "west")
			Application.LoadLevel("WestScene");
		else
			Debug.Log("Tu t'es trompé :/");
	}





	// Events
	public void CheckForEvent() // Looking for events occuring the current day
	{
		int i;
		for(i= 0; i < gOList.Count; i++)
		{
			if(gOList[i] != null && gOList[i].GetComponent<EventScript>().getDepartInt() == day)
			{
				ActiveEvent(gOList[i].GetComponent<EventScript>().getReference(), gOList[i]);
			}
		}
	}

	static public void ActiveEvent(int reference, GameObject caller)
	{
		switch(reference)
		{
		case 1:

			break;
		case 2:
			break;
		case 3:
			break;
		case 4:
			break;
		}
	}




	// Time

	public void UpdateTimeState()
	{
		if(countDownBeforeDoom == -1)
		{
			if((0 < hour && hour < 7 ) || (19 < hour))
			{
				currentState = "NIGHT";
			}
			else if(7 < hour && hour < 19)
			{
				currentState = "DAY";
			}
			else
			{
				Debug.Log("DAFUQ");
			}
		}
		else
		{
			if((0 < hour && hour < 7 + 12/(countDownBeforeDoom/2) ) || (19 - 12/(countDownBeforeDoom/2) < hour))
			{
				currentState = "NIGHT";
			}
			else if(7 - 12/(countDownBeforeDoom/1.5) < hour && hour < 12/(countDownBeforeDoom/1.5) + 19)
			{
				currentState = "DAY";
			}
			else
			{
				Debug.Log("DAFUQ");
			}
		}
	}

	IEnumerator BigBen()
	{
		while(!stopBigBen)
		{
			yield return new WaitForSeconds(20);
			hour += 0.5f;

			if(hour == 24)
			{
				hour = 0;
				day++;
				CheckForEvent();
				if(countDownBeforeDoom > 0)
				{
					countDownBeforeDoom --;
				}
			}
			UpdateTimeState();
			Debug.Log(hour);
			Debug.Log(currentState);
		}
	}



}
