using UnityEngine;
using System.Collections;

public class AI_Monster : MonoBehaviour {
	
	float rateMove;
	float sumDelta;

	// Use this for initialization
	void Start () {
		rateMove = 0.5f;
		sumDelta = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(GM.engage)
		{
			this.transform.position = Vector3.MoveTowards(this.transform.position, GM.player.transform.position, Time.deltaTime*1f);
		}
	}
}
