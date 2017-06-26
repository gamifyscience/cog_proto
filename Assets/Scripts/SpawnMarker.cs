using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchScript.Gestures;
using TouchScript;
public class SpawnMarker : MonoBehaviour {


	//This script will spawn a marker where the player taps so we can see the destination of the player on screen.
	public GameObject DestinationMarker;
	RaycastHit hit;
	// Use this for initialization
	void Start () {
		
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

	private void MoveMarkerTo(Vector2 position)
	{
		Ray ray = Camera.main.ScreenPointToRay(position);
		if (Physics.Raycast (ray.origin, ray.direction, out hit)) {
			if (hit.point [1] <= 0.9f) {
				
				Instantiate (DestinationMarker, hit.point, Quaternion.identity);
			}
		}
	}

	private void touchesBeganHandler(object sender, TouchEventArgs e)
	{
		foreach (var point in e.Touches)
		{
			MoveMarkerTo(point.Position);

		}

	}
		
}
