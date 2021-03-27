using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishControl : MonoBehaviour {

	HealthControl healthControl;
	void Start()
	{
		healthControl = GameObject.Find ("HealthControl").GetComponent <HealthControl> ();

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		 
		if (collision.gameObject.name.Equals("Border"))
		{
					
			Destroy (this.gameObject);

			if (this.gameObject.name.Equals ("Virus(Clone)")  )
			{
				healthControl.DecreaseLife () ;
			}

			if (this.gameObject.name.Equals("BigVirus(Clone)")) {
				healthControl.BigVirusDecreaseLife ();
			}
	
			
		}
	}
}


