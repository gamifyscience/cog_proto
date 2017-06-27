using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCamera : MonoBehaviour {
	
	public GameObject webcamPlane;
	GameObject camParent;
	// Use this for initialization
	void Start () {
		camParent = new GameObject ("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		camParent.transform.Rotate (Vector3.left, 90);
		Input.gyro.enabled = true;

		WebCamTexture webcamTexture = new WebCamTexture ();

		#if UNITY_IOS
			webcamPlane.GetComponent<MeshRenderer> ().material.mainTexture = webcamTexture;
//			scaleY = webcam.videoVerticallyMirrored ? -1.0 : 1.0;
//			webcamTexture.transform.localScale = new Vector3(width, scaleY * height, 0.0);
		#elif UNITY_ANDROID
			webcamPlane.GetComponent<MeshRenderer> ().material.mainTexture = webcamTexture;

		#endif

		webcamTexture.Play ();

	}

	// Update is called once per frame
	void Update () {
	 Quaternion rotFix = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y - 90, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
	 this.transform.localRotation = rotFix;

	}
}﻿
