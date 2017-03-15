using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideParticle : MonoBehaviour {

	//public GameObject effects;
	private ParticleSystem ps;  //script trigger this button
	public ParticleSystem.MainModule ma;
	//public ParticleSystem.MainModule main;

	// Use this for initialization
	void Awake () {

		msManager.StartListening ("Targeted", Targeted);
		msManager.StartListening ("Untargeted", Untargeted);
		msManager.StartListening ("BarelyTargeted", BarelyTargeted);

		//setup the particle system class
		ps = GetComponent<ParticleSystem>();
		ma = ps.main; //to control settings
	}

	void Start()
	{
		if (!DroneTargeting.Instance.HasTarget ())
			Untargeted ();
	}

	public void Targeted()
	{
		ps.Play();
		ma.maxParticles = 56;

	}

	public void BarelyTargeted()
	{
		ma.maxParticles = 8;
	}


	public void Untargeted()
	{
		//ps.Stop();
	}

}
