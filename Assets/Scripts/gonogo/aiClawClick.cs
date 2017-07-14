using UnityEngine;
using System.Collections;

public class aiClawClick : MonoBehaviour {

	public GameObject aiClaw;
	public Animator aiClaw_a;


	// Use this for initialization
	void OnEnable () {
		msManager.StartListening ("aiGrab", aiGrab);
		msManager.StartListening ("aiPass", aiPass);
	}

	void OnDisable () {
		msManager.StopListening ("aiGrab", aiGrab);
		msManager.StopListening ("aiPass", aiPass);
	}

	public void aiGrab()
	{
		//animate the grab
		aiClaw_a.SetTrigger("Grab");
	}

	void aiPass ()
	{
		//animate the grab
		aiClaw_a.SetTrigger("Grab");
	}

}