using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BestTime : MonoBehaviour {

	public UnityEngine.UI.Text BestTimeText;
	
	void Start () {
		
		BestTimeText.text = "Best Time :" + (((int)PlayerPrefs.GetFloat ("BestTime")) / 60) + ":" + (((int)PlayerPrefs.GetFloat ("BestTime")) % 60 ); 
	}
	

}
