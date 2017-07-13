using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDrone : MonoBehaviour {

	public Transform t_TargetDrone;
	private bool isAtTarget;

	// Use this for initialization
	void Start () {
		enabled = false;
		isAtTarget = false;
	}

	void OnEnable ()
	{
		msManager.StartListening("Targeted", Targeted);
		msManager.StartListening("Untargeted", Untargeted);
	}


	private void OnDestroy()
	{
		msManager.StopListening("Targeted", Targeted);
		msManager.StopListening("Untargeted", Untargeted);

	}
	void Targeted ()
	{
		isAtTarget = false;
		enabled = true; 
		//TBD do some animation and on off stuff
	}


	void Untargeted ()
	{
		transform.position = new Vector3 (0f, 0f, 0f);
		enabled = false;

	}

	// Update is called once per frame
	void Update () 
	{
		if (t_TargetDrone && isAtTarget) {
			//move from location to target
			transform.position = t_TargetDrone.position;
		} else if(t_TargetDrone) {
			//move from location to target
			transform.position = Vector3.MoveTowards (transform.position, t_TargetDrone.position, 3.5f);
			if (transform.position == t_TargetDrone.position) {
				//msManager.TriggerEvent ("StopMoving");
				isAtTarget = true;
			}
		}
	}
}
