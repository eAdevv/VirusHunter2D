using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimeControl : MonoBehaviour {
	
	public Text timerText;
	private float startTime;
	private bool finished = false;
	public float timescore = 0;

	HealthControl healthControlScript;

	void Start () {
		startTime = Time.time;
		healthControlScript = GameObject.Find ("HealthControl").GetComponent <HealthControl> ();

		if (PlayerPrefs.GetFloat("BestTime") <=1f) 
		{
			PlayerPrefs.SetFloat("BestTime", 10000);
		}
	}
	

	void Update () {
			timescore += Time.deltaTime;
		if (healthControlScript.lifeValue < 100f && healthControlScript.lifeValue > 0 && finished == false) {
			float t = Time.time - startTime;
			string minutes = ((int)t / 60).ToString ();
			string seconds = (t % 60).ToString ("f0");
			timerText.text = minutes + ":" + seconds;
			return;
		} else {
			finished = true;

			HighScore ();
		}
	}

	public void HighScore () {
		if (PlayerPrefs.GetFloat ("BestTime") > timescore && healthControlScript.lifeValue > 100f)
			PlayerPrefs.SetFloat ("BestTime", timescore);
			PlayerPrefs.Save ();
			
		}
	}



		
