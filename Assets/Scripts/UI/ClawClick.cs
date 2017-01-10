using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ClawClick : MonoBehaviour {

	public GameObject Claw;
	public Animator Claw_a;
	//public Animation Claw_anim;

	public float threshhold;

	// Use this for initialization
	void OnEnable () {
		msManager.StartListening ("Grab", Grab);
		msManager.StartListening ("SpawnBox", SpawnBox);
	}

	void Awake ()
	{
		Claw = GameObject.Find("Claw_Model");
		//Animator Claw_a = Animator.FindObjectOfType<Animator>();
		Claw_a = GetComponent<Animator>();
		//Claw_a.SetTrigger("Grab"); 
	}

	public void Grab()
	{
		Claw_a.SetTrigger("Grab"); 
	}

	public void ControlTrack (float threshold)
	{
		if (threshold >= 99)
			msManager.TriggerEvent ("Grab");

		//TEMP record an event that the player started to grab on an error but stopped
		//if (threshold > 60 && threshold < 80)
		//	msManager.TriggerEvent ("Impulse");
	}

	public void SpawnBox() 
	{ 
		Claw_a.SetTrigger("Retract"); 
	}
}
