using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class OrbNav : MonoBehaviour {

	public TapGesture FingertapGesture;
	public ScreenTransformGesture ManipulationGesture;
	public float PanSpeed = 100f;
	public float RotationSpeed = 100f;
	public float ZoomSpeed = 10f;

	private Transform pivot;
	private Transform playercamera;

	private void Awake()
	{
		pivot = transform.Find("Orb");
		playercamera = transform.Find("Orb/PlayerCamera");
	}

	private void OnEnable()
	{
		FingertapGesture.Tapped += fingertapGestureRot;

		ManipulationGesture.Transformed += manipulationTransformedHandler;
	}

	private void OnDisable()
	{
		//FingertapGesture -= FingertapGestureRot;
		ManipulationGesture.Transformed -= manipulationTransformedHandler;
	}

	private void manipulationTransformedHandler(object sender, System.EventArgs e)
	{
		
		//swipe L and R to pan
		var x_rotation = Quaternion.Euler(0,ManipulationGesture.DeltaPosition.x/Screen.width*PanSpeed,0);

		var y_rotation = Quaternion.Euler(ManipulationGesture.DeltaPosition.y/Screen.height*RotationSpeed, 0, 0); 
	
		pivot.localRotation *= x_rotation;
		playercamera.localRotation *= y_rotation;

		//pivot.transform.localPosition += Vector3.forward*(ManipulationGesture.DeltaScale - 1f)*ZoomSpeed;
	}

	private void fingertapGestureRot (object sender, System.EventArgs e)
	{
		//set the camera Orb to face the direction of the parent. This works becasue the rotatoin starts at 0,0,0
		//tbd make this a smooth transition
		pivot.localRotation = Quaternion.identity;
	}

}
