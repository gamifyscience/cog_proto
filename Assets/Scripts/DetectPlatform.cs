using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlatform : MonoBehaviour {
	//public GameObject PlayerObject;
	bool PlayerReady;
	private Component[] LiftEffect;

	// Use this for initialization
	void Start () {
		PlayerReady = false;

	}

	void OnTriggerEnter (Collider other)
	{
		//make verything visible now - congrats!
		//toggle player status so this wont turn things off again
		if (PlayerReady == false) {
			LiftEffect = GetComponentsInParent (typeof(MeshRenderer));
			if (LiftEffect != null) {
				foreach (MeshRenderer Toggle in LiftEffect)
					Toggle.enabled = !Toggle.enabled;
			} 
			PlayerReady = true;	

		}
	}

}
