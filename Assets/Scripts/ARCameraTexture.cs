using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARCameraTexture : MonoBehaviour {

	public GameObject webcamPlane;
	private WebCamTexture webcamTexture;
	public WebCamDevice[] devices;


	// Use this for initialization
	void Start () {
		devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture ();
		webcamPlane.GetComponent<MeshRenderer> ().material.mainTexture = webcamTexture;
		webcamTexture.deviceName = devices[0].name;
		webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI()
	{
		if( GUI.Button( new Rect(100,0,100,100), "switch" ))
		{

			webcamTexture.Stop();
			if (devices.Length >1)
				webcamTexture.deviceName = (webcamTexture.deviceName == devices[0].name) ? devices[1].name : devices[0].name;

			webcamTexture.Play();
		}
	}
}
