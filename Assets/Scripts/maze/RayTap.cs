using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using TouchScript;


public class RayTap : MonoBehaviour {

	RaycastHit hitInfo = new RaycastHit();
	NavMeshAgent agent;

	//for the run animation times
	Vector2 smoothDeltaPosition = Vector2.zero;
	Vector2 velocity = Vector2.zero;
	//public Camera MainCam;

	public GameObject PlayerBody;
	public Animator PlayerMoves;

	void Start() {
		agent = GetComponent<NavMeshAgent>();
		// Don’t update position automatically
		//agent.updatePosition = false;
	}

	private void OnEnable()
	{
		if (TouchManager.Instance != null)
		{
			TouchManager.Instance.TouchesBegan += touchesBeganHandler;
		}
	}

	private void OnDisable()
	{
		if (TouchManager.Instance != null)
		{
			TouchManager.Instance.TouchesBegan -= touchesBeganHandler;
		}
	}

	private void MovePlayerAt(Vector2 position)
	{
		Ray ray = Camera.main.ScreenPointToRay (position);

		if (Physics.Raycast (ray.origin, ray.direction, out hitInfo) && agent != null)
		{
			//test for ground level
			if (hitInfo.point [1] <= 3.0f) {
				agent.destination = hitInfo.point;
			}
		}
	}

	private void touchesBeganHandler(object sender, TouchEventArgs e)
	{
		foreach (var point in e.Touches)
		{
			MovePlayerAt(point.Position);
		}

	}


	void Update() {

		if (agent != null) 
		{

		 Vector3 worldDeltaPosition = agent.destination - transform.position;
		
		//print ("agent.nextPosition: " + agent.destination.ToString ()+transform.position.ToString());
		// Map 'worldDeltaPosition' to local space
		float dx = Vector3.Dot (transform.right, worldDeltaPosition);
		float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
		Vector2 deltaPosition = new Vector2 (dx, dy);

		// Low-pass filter the deltaMove
		float smooth = Mathf.Min(1.0f, Time.deltaTime/0.15f);
		smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		// Update velocity if time advances
		if (Time.deltaTime > 1e-5f)
			velocity = smoothDeltaPosition / Time.deltaTime;
			//check to see if the animation vectorX is a number
			if(float.IsNaN(velocity[0]))
				velocity = Vector2.zero;
			//print ("velocity: " + velocity.magnitude.ToString ());
		bool shouldMove = velocity.magnitude > 1.19f && agent.remainingDistance > agent.radius;
			//print ("shouldMove: " + shouldMove);

		 //print ("velocity: " + velocity.ToString ());
		// Update animation parameters
				 PlayerMoves.SetBool("run", shouldMove);
			/* RUNNNING AND STOPPING ANIMATIONS in BLEND TREE
				 PlayerMoves.SetFloat ("VelX", velocity.x);	*/
				 PlayerMoves.SetFloat ("VelY", velocity.y);

		}else {
			print("noplayer");
		}
	}
		
}
