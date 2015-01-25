using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//CEST PAS BO MAIS CA MARCHE
public class GetText : MonoBehaviour {

	static Text textPrint;
	static GameObject dialogueCanvas;
	static GameObject dialogueText;
	static GameObject dialogueButton;

	void Awake (){
		dialogueCanvas = GameObject.Find("DialogueCanvas");
		dialogueText = GameObject.Find("DialogueText");
		dialogueButton = GameObject.Find ("DialogueButtonOK");
		textPrint = dialogueText.GetComponent<Text>();
	}

	void Start (){
		dialogueCanvas.SetActive(false);

	}


	public static void SetText(int dialNum){
		string dialogue;
		XMLParsing xmlParse;
		dialogueCanvas.SetActive(true);
		GM.displaying = true;
		dialogue = XMLParsing.getDialogue(dialNum); 
		textPrint.text = "I saved your life man ! Please go scrap some dead wood for the fire, the night will be long... And kid, if you see a key like mine, bring it back." ; // Pour un joli affichage du bouton
	}



}
