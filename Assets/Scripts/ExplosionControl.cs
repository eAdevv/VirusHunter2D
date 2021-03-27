using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionControl : MonoBehaviour
{
	public GameObject explosionVirus, explosionRedBlood;
	HealthControl healthControl;
	CreateVirus voice;
	float NumOfClick = 0;

	

	void Start()
	{
		healthControl = GameObject.Find("HealthControl").GetComponent<HealthControl>();
		voice = GameObject.Find("VirusScripti").GetComponent<CreateVirus>();

	}

	void OnMouseDown()
	{
		NumOfClick += 1f;

		if (gameObject.name.Equals("Virus(Clone)"))
		{
			GameObject VirusExplosion = Instantiate(explosionVirus, transform.position, transform.rotation) as GameObject;
			Destroy(this.gameObject);
			Destroy(VirusExplosion, 0.407f);
			healthControl.IncreaseLife();
			voice.VirusVoice();

		}


		else if (NumOfClick == 2f)
		{

			GameObject BigVirusExplosion = Instantiate(explosionVirus, transform.position, transform.rotation) as GameObject;
			Destroy(this.gameObject);
			Destroy(BigVirusExplosion, 0.407f);
			healthControl.BigVirusIncreaseLife();
			voice.VirusVoice();

		}

		if (gameObject.name.Equals("redblood(Clone)"))
		{
			GameObject RedBloodExplosion = Instantiate(explosionRedBlood, transform.position, transform.rotation) as GameObject;
			Destroy(this.gameObject);
			Destroy(RedBloodExplosion, 0.413f);
			healthControl.DecreaseLife();
			voice.RedBloodVoice();

		}

	}

}
