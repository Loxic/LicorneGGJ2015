using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GetText : MonoBehaviour {

	public int dialNum;
	private XMLParsing xmlParse;
	string dialogue;
	Text textPrint;
	private GameObject dialogueHandler;


	public void Start(){
		//dialogueHandler = GameObject.Find ("DialogueHandler");
		textPrint = GetComponent<Text>();
		//xmlParse = dialogueHandler.GetComponent<XMLParsing>();
		dialogue = XMLParsing.getDialogue(dialNum); 
		textPrint.text = dialogue + "\n"; // Pour un joli affichage du bouton
	}



}
