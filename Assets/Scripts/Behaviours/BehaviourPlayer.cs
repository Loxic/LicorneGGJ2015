using UnityEngine;
using System.Collections;

public class BehaviourPlayer : MonoBehaviour {

	int amountFirewood = 0, amountFood = 0, maxFood = 5, maxFirewood = 15;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
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
	
	
	public bool TakeFood()
	{
		if(amountFood < maxFood)
		{
			amountFood ++;
			GM.food ++;
			return true;
		}
		else
			return false;
	}

	public bool TakeWood()
	{
		if(amountFirewood < maxFirewood)
		{
			amountFirewood ++;
			GM.firewood ++;
			return true;
		}
		else
			return false;
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
