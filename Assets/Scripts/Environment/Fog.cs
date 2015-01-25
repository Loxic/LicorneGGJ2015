using UnityEngine;
using System.Collections;

public class Fog : MonoBehaviour {
	
	float timeOfDay;
	int dayNumb;
	int morning;
	int evening;
	Color myColor;

	// Use this for initialization
	void Start () {
		Debug.Log("Fog initialised");
		int count = GM.countDownBeforeDoom;
		timeOfDay = GM.hour;
		dayNumb = (int)GM.day;
		if(count > 0){
			morning = 7+12/(count/2);
			evening = 19-12/(count/2);
		}
		else{
			morning = 7;
			evening = 19;
		}
		RenderSettings.fog = true;
		//myColor = new Color(89, 88, 96, 255);
		RenderSettings.fogColor = new Color((89f/255f), (88f/255f), (96f/255f), 1f);
		RenderSettings.flareStrength = 1;
		RenderSettings.flareFadeSpeed = 3;
		RenderSettings.ambientLight = new Color(0,0,0,255);
		RenderSettings.fogDensity = 0.05f;
		RenderSettings.fogEndDistance = 1;
		RenderSettings.fogStartDistance = 0;
		RenderSettings.fogMode = FogMode.ExponentialSquared;
		RenderSettings.haloStrength = 0.5f;
		//RenderSettings.skybox = Resources.Load("Materials/skybox", typeof(Material)) as Material;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(GM.hour);
		if(timeOfDay+1 <= GM.hour){
			Debug.Log("Updating fog !");
			updateSkyBox();
			timeOfDay = GM.hour;
		}
	}

	void updateSkyBox(){
		int red = 89 - (int)((29)*(timeOfDay-morning)/(evening-morning));
		int green = 88 - (int)((82)*(timeOfDay-morning)/(evening-morning));
		int blue = 96 - (int)((90)*(timeOfDay-morning)/(evening-morning));
		RenderSettings.fogColor = new Color((((float)red)/255f), (((float)green)/255f), (((float)blue)/255f), 1f);
	}
}
