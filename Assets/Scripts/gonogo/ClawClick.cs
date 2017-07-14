using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClawClick : MonoBehaviour {

	public GameObject Claw;
	public Animator Claw_a;

	// Use this for initialization
	private void OnEnable () {
		msManager.StartListening ("Grab", Grab);
		msManager.StartListening ("SpawnBox", SpawnBox);

	}

	public void Grab()
	{
		Claw_a.SetTrigger("Grab"); 
	}


	public void ControlTrack (float threshold)
	{
		//TEMP record an event that the player started to grab on an error but stopped
		//if (threshold > 60 && threshold < 80)
		//	msManager.TriggerEvent ("Impulse");
	}

	public void SpawnBox() 
	{ 
		Claw_a.SetTrigger("Retract"); 
	}
}
