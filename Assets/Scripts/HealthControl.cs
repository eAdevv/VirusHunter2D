using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;




public class HealthControl : MonoBehaviour
{
	public UnityEngine.UI.Button playagain, back;
	public UnityEngine.UI.Image LifeBar, patientRecovered, patientDie;
	public AudioClip positive, negative;
	public float lifeValue = 2.5f;
	public GameObject explosionVirus, explosionRedBlood;

	void Start()
	{
		LifeBar.fillAmount = lifeValue / 100;
	}

	public void IncreaseLife()
	{
		if (lifeValue < 100f)
		{
			lifeValue += 1.5f;
			LifeBarControl();
		}

		else
		{
			If_PatientRecovered();
		}
	}

	public void BigVirusIncreaseLife()
	{
		if (lifeValue < 100f)
		{
			lifeValue += 2.5f;
			LifeBarControl();
		}

        else
        {
			If_PatientRecovered();
		}
		
	}

	public void DecreaseLife()
	{

		if (lifeValue > 0)
		{
			lifeValue -= 2.5F;
			LifeBarControl();
	 	}

       if(lifeValue <= 0)
        {
			If_PatientDie();
		}

	}

	public void BigVirusDecreaseLife()
	{
		
		if (lifeValue > 0)
		{
			lifeValue -= 7F;
			LifeBarControl();
		}


		if (lifeValue <= 0)
		{
			If_PatientDie();
		}

	}


	public void If_PatientRecovered()
	{

		    EndGame_Explosion_Anims();

			patientRecovered.enabled = true;
			GetComponent<AudioSource>().Stop();
			playagain.gameObject.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(positive, 1f);
			back.gameObject.SetActive(true);

	}

	public void If_PatientDie()
    {
			EndGame_Explosion_Anims();

			patientDie.enabled = true;
			GetComponent<AudioSource>().Stop();
			playagain.gameObject.SetActive(true);
			GetComponent<AudioSource>().PlayOneShot(negative, 1f);
			back.gameObject.SetActive(true);
	
	}

	public void LifeBarControl()
    {
		float life = lifeValue / 100;
		LifeBar.fillAmount = life;
		LifeBar.color = Color.Lerp(Color.white, Color.white, life);
	}

	public void EndGame_Explosion_Anims()
    {
		GameObject[] Viruses = GameObject.FindGameObjectsWithTag("Virus");
		GameObject[] RedBloods = GameObject.FindGameObjectsWithTag("RedBlood");
		GameObject[] BigViruses = GameObject.FindGameObjectsWithTag("BigVirus");



		for (int i = 0; i < Viruses.Length; i++)
		{
			GameObject Virus_Explosion = Instantiate(explosionVirus, Viruses[i].transform.position, Viruses[i].transform.rotation);
			Destroy(Viruses[i]);
			Destroy(Virus_Explosion, 0.407f);
		}

		for (int i = 0; i < RedBloods.Length; i++)
		{
			GameObject RedBlood_Explosion = Instantiate(explosionRedBlood, RedBloods[i].transform.position, RedBloods[i].transform.rotation);
			Destroy(RedBloods[i]);
			Destroy(RedBlood_Explosion, 0.413f);
		}

		for (int i = 0; i < BigViruses.Length; i++)
		{
			GameObject BigVirus_Explosion = Instantiate(explosionVirus, BigViruses[i].transform.position, BigViruses[i].transform.rotation);
			Destroy(BigViruses[i]);
			Destroy(BigVirus_Explosion, 0.413f);
		}
	}
}
