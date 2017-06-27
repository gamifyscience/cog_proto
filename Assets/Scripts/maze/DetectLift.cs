using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using Fabric.Answers;

public class DetectLift : MonoBehaviour {

	public GameObject PlayerObject;
	private Component[] LiftEffect;
	public Animator LiftUp;
	private bool PlayerReady;
	public GameObject digitTimer;
	float RoundTime;


	// Use this for initialization
	void Start () {
		PlayerReady = false;
	}


	//Player must find the hidden platform
	//when they find the platform hide the hints and enable the visuals to prepare the lift
	void OnTriggerEnter (Collider other)
	{
		/*	LiftEffect = GetComponentsInChildren(typeof (MeshRenderer));
		if (LiftEffect != null)
		{
			foreach (MeshRenderer Toggle in LiftEffect)
				Toggle.enabled = !Toggle.enabled;

		}*/

		//parent the Player to the platform to make the animation smoother
		PlayerObject.transform.parent = this.gameObject.transform;
		PlayerReady = true; //checked on Update to end the level

		//WORKAROUND: there is an issue with the platform not picking up the player unless the NavMeshAgent on the player is disabled
		//since the player is now a child we can rehash the previous component check to disable it
		LiftEffect = GetComponentsInChildren(typeof (NavMeshAgent));

		if (LiftEffect != null)
		{
			foreach (NavMeshAgent Toggle in LiftEffect)
				Toggle.enabled = false;
		}

	}

	// Update is called once per frame
	void Update () {
		if (PlayerReady == true)
			PlayerExit ();
	}

	void PlayerExit ()
	{
		//Tell the clock to stop and record time
		RoundTime = digitTimer.GetComponent<DigitTimer>().RecordTime ();
		AnswerCustom.LogMazeEscapeInterval ("MorrisMazeTime", "Time to Find Platform", RoundTime);
		//animate the exit
		LiftUp.SetTrigger("Up");
		//resetplayer
		PlayerReady = false;
	}

}
