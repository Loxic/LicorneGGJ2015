using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	// Ressources
	static public int firewood = 0, food = 0, keys = 0; // measure in units
	static public GameObject player;
	static public GameObject npc;
	static public GameObject badGuy;
	static public GameObject rambo;
	static public GameObject bidoche;
	static public GameObject cleJaune;
	static public GameObject cleVerte;
	static public GameObject cleBleue;
	static public GameObject cleRouge;
	static public bool engage = false;
	static public bool displaying = true;
	static public int groupStatus = -1;

	// Time system variables
	//static public float day = 0, hour = 0;
	static public float day = 0;
	static public float hour = 8;
	static public string currentState = "DAY";
	static public bool stopBigBen = false;
	static public int countDownBeforeDoom = -1;
	public enum Compagnon {rambo, pnj, badGuy};
	public enum Heure {matin, soir};


	// event material
	static List<GameObject> gOList;
	bool win = false;



	void Start () {


		gOList = new List<GameObject>();


		DontDestroyOnLoad(transform.gameObject);

	




	}


	void Update () {
	
		if(currentState == "NIGHT")
			NightHasFallen();

		if(!displaying)
			Screen.lockCursor = true;

	}


	public void Newgame()
	{
		Application.LoadLevel("Camp");
		displaying = false;
	}

	void OnLevelWasLoaded()
	{

		StartCoroutine(BigBen());
		
		player = GameObject.FindWithTag("Player");
		npc = GameObject.FindWithTag("Npc");
		badGuy = GameObject.FindWithTag("BadGuy");
		bidoche = GameObject.Find("bidoche");
		cleJaune = GameObject.Find("yellow_key");
		cleVerte = GameObject.Find("green_key");

		if(npc != null)
		{
			npc.SetActive(false);
		}
		if(badGuy != null)
		{
			badGuy.SetActive(false);
		}
		if(bidoche != null)
		{
			bidoche.SetActive(false);
		}
		if(cleJaune != null)
		{
			cleJaune.SetActive(false);
		}
		if(cleVerte != null)
		{
			cleVerte.SetActive(false);
		}

		// filling gOList
		GameObject[] byTags = GameObject.FindGameObjectsWithTag("Timed");
		int i;
		for(i=0;i<byTags.Length; i++)
		{
			gOList.Add(byTags[i]);
			byTags[i].SetActive(false);
		}
		CheckForEvent();
		Debug.Log("Love it !");
	}

	// Scenes management

	public void Restart()
	{
		Application.LoadLevel(Application.loadedLevel);
	}

	static public void GameOver(string statement)
	{
		Application.LoadLevel("");
	}






	// Events
	public void CheckForEvent() // Looking for events occuring the current day
	{
		int i;
		if(gOList.Count == 0)
		{
		}
		else if(gOList.Count > 0)
		{
			for(i= 0; i < gOList.Count; i++)
			{
				if(gOList[i] != null && gOList[i].GetComponent<EventScript>().getDepart() == day)
				{
					ActiveEvent(gOList[i].GetComponent<EventScript>().getReference(), gOList[i]);
				}
			}
		}

	}

	static public void ActiveEvent(int reference, GameObject caller)
	{

		switch(reference)
		{
		case -99:
			//Character death
			if(caller == player)
			{
				GameOver("Vous etes mort.");
			}
			else
			{
				caller.GetComponent<AI_NPC>().enabled = false;
				Destroy(caller);
			}
			break;
		case 0:
			Application.LoadLevel("Foret");
			//Rajouter des batons
			break;
		case -1:
			Application.LoadLevel("Riviere");
			//rajouter des boites
			break;
		case 1:
			GameObject preRambo = (GameObject)Resources.Load<GameObject>("Prefabs/rambo");
			rambo = Instantiate(preRambo, GameObject.Find("spawn").transform.position,  GameObject.Find("spawn").transform.rotation) as GameObject;
			break;
		case 2:
			GameObject preNPC = (GameObject)Resources.Load<GameObject>("Prefabs/NPC");
			npc = Instantiate(preNPC, GameObject.Find("spawn").transform.position,  GameObject.Find("spawn").transform.rotation) as GameObject;
			npc.SendMessage("FirstMeetingPlayer");
			break;
		case 3:
			npc.SetActive(false);
			break;
		case 4:
			GameObject preBadGuy = (GameObject)Resources.Load("Prefabs/badguy");
			badGuy = Instantiate(preBadGuy, GameObject.Find("spawn").transform.position,  GameObject.Find("spawn").transform.rotation) as GameObject;
			break;
		case 5:
			bidoche.SetActive(true);
			cleJaune.SetActive(true);
			break;
		case 6:
			/* INSEREZ ICI VOTRE PROGRAMME BATARD. ILS VONT SOUFFRIR */
			break;
		case 7:
			player.SendMessage("MadnessIsComing");
			npc.SendMessage("MadnessIsComing");
			break;
		case 8:
			//Prendre a manger :D
			if(player.GetComponent<BehaviourPlayer>().TakeFood())
			{
				Destroy(caller);
			}
			break;
		case 9:
			//Prendre a manger :D
			if(player.GetComponent<BehaviourPlayer>().TakeWood())
			{
				Destroy(caller);
			}
			break;
		case 10:
			rambo.SendMessage("Die");
			break;
		case 11:
			bidoche.SetActive(true);
			cleJaune.SetActive(true);
			break;
		case 666:
			break;
		}
	}


	//Dialogue index handler
	public static int GetIndex(int compagnon, int jour, int heure){
		if(compagnon == (int) Compagnon.rambo){
			if((jour == -1)){
				return 0;
			}
			if((jour == 0) && (heure == (int) Heure.matin)){
				return 1;
			}
			else if((jour == 0) && (heure == (int) Heure.soir)){
				return 2;
			} 
			
			else if((jour == 1) && (heure == (int) Heure.matin)){
				return 3;
			}
		}
		else if(jour < 15 && jour > 4){
			if(compagnon == (int) Compagnon.pnj){
				return 2*jour-6+heure;
			}
			else{
				return -1;
			}
			
		}
		else if(jour == 15){
			if((heure == (int) Heure.matin) && (compagnon == (int) Compagnon.pnj)){
				return 23;
			}
			else if(compagnon == (int) Compagnon.badGuy){
				return 24 + heure; //heure = 0 matin, 1 soir
			}
			else if((compagnon == (int) Compagnon.pnj) && (heure == (int) Heure.soir)){
				return 55; //PROBBBBLEEEEEEME §§§§§§ (Le joueur a vu le BadGuy ou pas quel dialogue choisir ?
			}	
		}
		else if((jour > 15) && (compagnon == (int) Compagnon.badGuy)){
			return 2 * jour - 7 + heure;
		}
		else if((jour > 15) && (compagnon == (int) Compagnon.pnj)){
			return 32 + 2*jour - 7 + heure;
		}
		
		return -1;
		
	}


	// Time
	public void NightHasFallen()
	{
		GameObject fire = GameObject.Find("firecamp");
		if(fire != null)
		{
			if((player.transform.position - fire.transform.position).magnitude > 5)
				player.SendMessage("Die");
			else
			{day++; hour = 8; firewood = firewood - 12;
				if(firewood < 0) Application.LoadLevel("road");}
		}
		else
		{
			player.SendMessage("Die");
		}
	}


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
			yield return new WaitForSeconds(4.5f);
			hour += 1;

			if(hour == 12)
			{
				day+=0.5f;
				CheckForEvent();

			}
			if(hour == 24)
			{
				hour = 0;
				CheckForEvent();
				if(countDownBeforeDoom > 0)
				{
					countDownBeforeDoom --;
				}
			}
			UpdateTimeState();
			Debug.Log(day);
		}
	}



}
