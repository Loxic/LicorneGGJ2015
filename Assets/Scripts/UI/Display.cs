using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Display : MonoBehaviour {

	private GameObject displayCanvas;
	private Text textPrint;

	void Awake (){
		displayCanvas = GameObject.Find ("DisplayCanvas");
		textPrint = GameObject.Find("DisplayText").GetComponent<Text> ();
		}

	void Start (){
		displayCanvas.SetActive (false);
	}

	public void DisplayWood(int nb){
		displayCanvas.SetActive (true);
		textPrint.text = "Remaining wood : \n" + nb;
		StartCoroutine("endTextDisplay");
	}

	public void DisplayFood(int nb){
		displayCanvas.SetActive (true);
		textPrint.text = "Remaining food : \n" + nb;
		StartCoroutine("endTextDisplay");
	}

	IEnumerator endTextDisplay()
	{
		yield return new WaitForSeconds(2);
		displayCanvas.SetActive(false);
	}
	
}
