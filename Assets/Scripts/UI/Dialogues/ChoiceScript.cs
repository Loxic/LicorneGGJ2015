using UnityEngine;
using System.Collections;

public class ChoiceScript : MonoBehaviour {

	private GameObject ressourceCanvas;
	private GameObject zoneCanvas;
	private GameObject yesSirPanel;
	private GameObject choicePanel;
	private GameObject goFindSomeWoodPanel;
	private GameObject goFindSomeFoodPanel;
		
	enum what {nothing, wood, food};
	enum where {clearing, forest, outerregions};

	private int ressource;
	private int difficulty;


	void Awake(){
		ressourceCanvas = GameObject.Find("RessourceCanvas");
		zoneCanvas = GameObject.Find("ZoneCanvas");
		choicePanel = GameObject.Find ("ChoicePanel");
		yesSirPanel = GameObject.Find("YesSirPanel");
		goFindSomeWoodPanel = GameObject.Find("GoWoodPanel");
		goFindSomeFoodPanel = GameObject.Find("GoFoodPanel");
	}

	void Start(){
		if(choicePanel != null)
		choicePanel.SetActive (false);
		if(zoneCanvas != null)
		zoneCanvas.SetActive (false);
		if(ressourceCanvas != null)
		ressourceCanvas.SetActive (false);
		if(yesSirPanel != null)
		yesSirPanel.SetActive (false);
		if (goFindSomeWoodPanel != null)
		goFindSomeWoodPanel.SetActive (false);
		if (goFindSomeFoodPanel != null)
		goFindSomeFoodPanel.SetActive (false);

	}


	public void StartChoice(){
		if (GM.day == 0) {
			print("WOOD ACTIVE");
			goFindSomeWoodPanel.SetActive(true);
		}
		else if (GM.day == 1) {
			print("FOOD ACTIVE");
			goFindSomeFoodPanel.SetActive(true);
		}
		else {
			choicePanel.SetActive (true);
			ressourceCanvas.SetActive (true);
		}
	}
	                       

		

	public void RessourceChosen(int choice){

		if (choice == (int)what.nothing) {
			ressource = choice;
			ressourceCanvas.SetActive (false);
			yesSirPanel.SetActive(true);
			
		}
		else if (choice == (int)what.food){
			ressource = choice;
			ressourceCanvas.SetActive(false);
			zoneCanvas.SetActive(true);
		}
		else if(choice == (int)what.wood){
			ressource = choice;
			ressourceCanvas.SetActive(false);
			zoneCanvas.SetActive(true);
		}
		
	}
	
	public void  zoneChosen(int choice){
			if (choice == (int)where.clearing) {
					difficulty = choice + 1;
					choicePanel.SetActive (false);
					yesSirPanel.SetActive (true);
			} else if (choice == (int)where.forest) {
					difficulty = choice + 1;
					choicePanel.SetActive (false);
					yesSirPanel.SetActive (true);
			} else if (choice == (int)where.outerregions) {
					difficulty = choice + 1;
					choicePanel.SetActive (false);
					yesSirPanel.SetActive (true);
			}
	}
		

	public void LetsGo(){
		if (ressource == (int)what.food) {
			//GM.npc.GetComponent<AI_NPC> ().SentToMissionFood (difficulty);
		}
		else if (ressource == (int)what.wood) {
			//GM.npc.GetComponent<AI_NPC> ().SentToMissionWood (difficulty);
		}
		else if(ressource == (int)what.nothing) {

		}
		else
		print("PORTNAWAK TU SAIS PAS OU LENVOYER BOUFFER");


	
}









}
