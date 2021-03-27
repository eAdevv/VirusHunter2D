using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateVirus : MonoBehaviour {
	
	public GameObject Virus,BigVirus,redblood;
	float virus_timecounter = 0f;
	float redblood_timecounter = 0f;
	float bigvirusTimeCounter = 0f;
	float VirusCreationTime = 0.8f;
	float RedbloodCreationTime = 1.5f;
	float bigVirusCreationTime = 6f;
	HealthControl healthControlScript ;
	public AudioClip virus_voice,redblood_voice;
	float speed = 0;

	void Start () {
		healthControlScript = GameObject.Find ("HealthControl").GetComponent <HealthControl> ();
	}
		
	public void Update () {
		VirusCreate ();
	}

	public void VirusVoice()
	{
		GetComponent <AudioSource>().PlayOneShot(virus_voice, 1f);
		

	}

	public void RedBloodVoice()
	{
		GetComponent <AudioSource>().PlayOneShot (redblood_voice, 1f);
	}

	public void VirusCreate ()
	{

		{
			virus_timecounter -= Time.deltaTime;
			bigvirusTimeCounter -= Time.deltaTime;
			redblood_timecounter -= Time.deltaTime;
			if (healthControlScript.lifeValue < 10f) {
				speed = 1f;
				VirusCreationTime = 1f;
				RedbloodCreationTime = 1.3f;
				bigVirusCreationTime = 5f;
			} else if (healthControlScript.lifeValue < 25f) {
				speed = 1.3f;
				VirusCreationTime = 0.7f;
				RedbloodCreationTime = 1f;
				bigVirusCreationTime = 4f;
			} else if (healthControlScript.lifeValue < 50f) {
				speed = 1.5f;
				VirusCreationTime = 0.3f;
				RedbloodCreationTime = 0.8f;
				bigVirusCreationTime = 3f;
			} else if (healthControlScript.lifeValue <= 75f) {
				speed = 2f;
				VirusCreationTime = 0.2f;
				RedbloodCreationTime = 0.5f;
			}
			else if (healthControlScript.lifeValue > 75f) {
				speed = 2.3f;
				VirusCreationTime = 0.1f;
				RedbloodCreationTime = 0.4f;
			}

			if (virus_timecounter < 0 && redblood_timecounter < 0 && healthControlScript.lifeValue < 100f && healthControlScript.lifeValue > 0f) {
				
				if (VirusCreationTime > 0) {
					GameObject go_Virus =	Instantiate (Virus, new Vector3 (Random.Range (-2.5f, 2.5f), -6f, 0), Quaternion.Euler (0, 0, 0)) as GameObject; 
					go_Virus.GetComponent <Rigidbody2D> ().AddForce (new Vector3 (0, Random.Range (125f* speed, 180f* speed), 0));
					virus_timecounter = VirusCreationTime;
				}
				if (RedbloodCreationTime > 0.6f) {
					GameObject go_RedBlood = Instantiate (redblood, new Vector3 (Random.Range (-2.5f, 2.5f), -6f, 0), Quaternion.Euler (0, 0, 0)) as GameObject;
					go_RedBlood.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (0, 150f* speed, 0));
					RedbloodCreationTime -= 0.2f;
					redblood_timecounter = RedbloodCreationTime;
				} else {

					GameObject go_RedBlood = Instantiate (redblood, new Vector3 (Random.Range (-2.5f, 2.5f), -6f, 0), Quaternion.Euler (0, 0, 0)) as GameObject;
					go_RedBlood.GetComponent<Rigidbody2D> ().AddForce (new Vector3 (0 , 150f* speed, 0));
					redblood_timecounter = RedbloodCreationTime;
				} 

			}

			if (bigvirusTimeCounter < 0 && healthControlScript.lifeValue < 100f && healthControlScript.lifeValue > 0f) {
				if (bigVirusCreationTime > 0) {

					GameObject go_BigVirus =	Instantiate (BigVirus, new Vector3 (Random.Range (-2.5f, 2.5f), -6f, 0), Quaternion.Euler (0, 0, 0)) as GameObject; 
					go_BigVirus.GetComponent <Rigidbody2D> ().AddForce (new Vector3 (0, Random.Range (100f* speed, 150f* speed), 0));
					bigvirusTimeCounter = bigVirusCreationTime;
				}
			}

		}

	}


}
