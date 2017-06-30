using UnityEngine;
using System.Collections;

public class aiClawClick : MonoBehaviour {

	public GameObject aiClaw;
	public Animator aiClaw_a;
	//public Animation Claw_anim;

	// Use this for initialization
	void OnEnable () {
		msManager.StartListening ("aiGrab", aiGrab);
	}

	void Awake ()
	{
		aiClaw = GameObject.Find("Claw_Model");

		aiClaw_a = GetComponent<Animator>();
		//Claw_a.SetTrigger("Grab"); 
	}

	public void aiGrab()
	{
		aiClaw_a.SetTrigger("Grab");

	}
}