using UnityEngine;
using System.Collections;

public class ChoiceScript : MonoBehaviour {

	private GameObject ressourceCanvas;
	private GameObject zoneCanvas;
	private GameObject yesSirPanel;
	private GameObject choicePanel;
		
	enum what {nothing, wood, food};
	enum where {clearing, forest, outerregions};


	void Awake(){
		ressourceCanvas = GameObject.Find("RessourceCanvas");
		zoneCanvas = GameObject.Find("ZoneCanvas");
		choicePanel = GameObject.Find ("ChoicePanel");
		yesSirPanel = GameObject.Find("YesSirPanel");	
	}

	void Start(){
		choicePanel.SetActive (false);
		zoneCanvas.SetActive (false);
		ressourceCanvas.SetActive (false);
		yesSirPanel.SetActive (false);
	}

	
	/// Gros test à la con.
	void Update(){
		if (Input.GetKeyDown (KeyCode.F12)) {
			choicePanel.SetActive(true);
			ressourceCanvas.SetActive(true);
			}
		}

	public void RessourceChosen(int choice){
		if (choice == (int)what.nothing) {
			//GM.ActiveEvent(); //A COMPLETER
			ressourceCanvas.SetActive (false);
			yesSirPanel.SetActive(true);
			
		}
		else if (choice == (int)what.food){
			//GM.ActiveEvent(); //A COMPLETER
			ressourceCanvas.SetActive(false);
			zoneCanvas.SetActive(true);
		}
		else if(choice == (int)what.wood){
			//GM.ActiveEvent(); //A COMPLETER
			ressourceCanvas.SetActive(false);
			zoneCanvas.SetActive(true);
		}
		
	}
	
	public void  zoneChosen(int choice){
		if (choice == (int)where.clearing) {
			//GM.ActiveEvent(); //A COMPLETER
			choicePanel.SetActive(false);
			yesSirPanel.SetActive(true);
		}
		else if (choice == (int)where.forest){
			//GM.ActiveEvent(); //A COMPLETER
			choicePanel.SetActive(false);
			yesSirPanel.SetActive(true);
		}
		else if(choice == (int)where.outerregions){
			//GM.ActiveEvent(); //A COMPLETER
			choicePanel.SetActive(false);
			yesSirPanel.SetActive(true);
		}
	}









}
