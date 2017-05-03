using UnityEngine;
using System.Collections;

// Uses the phone's gyroscope to change the camera's rotation.
public class ARCameraController : MonoBehaviour
{
    private bool m_isUsingGyro = true;

	public GameObject webcamPlane;
	private WebCamTexture webcamTexture;
	public WebCamDevice[] devices;
	GameObject camParent;

    void Start()
	{
		/// for movement in real space
		Input.gyro.enabled = true;

		if (Application.isMobilePlatform) {
		camParent = new GameObject ("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		camParent.transform.Rotate (Vector3.right, 90);
			/*
			camParent.transform.eulerAngles = Vector3(90,90,0);
			if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
				quatMult = Quaternion(0,0,1,0); //**
			} else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
				quatMult = Quaternion(0,0,1,0); //**
			} else if (Screen.orientation == ScreenOrientation.Portrait) {
				quatMult = Quaternion(0,0,1,0); //**
			} else if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
				quatMult = Quaternion(0,0,0,1); // Unable to build package on upsidedown
			}
			*/
		}

		//get a list of cameras available - eg front 0 and back 1
		devices = WebCamTexture.devices;
		webcamTexture = new WebCamTexture ();
		webcamPlane.GetComponent<MeshRenderer> ().material.mainTexture = webcamTexture;
		webcamTexture.deviceName = devices[0].name;
		webcamTexture.Play();

        // If there's no gyroscope support, no Unity Remote, and we're in the editor, use
        // mouselook instead.
		#if UNITY_EDITOR

        if (!SystemInfo.supportsGyroscope && !UnityEditor.EditorApplication.isRemoteConnected)
        {
            gameObject.AddComponent<SimpleSmoothMouseLook>();
			Input.gyro.enabled = false;
            m_isUsingGyro = false;

        }
		#endif
    }

    void Update()
    {
		Quaternion rotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		this.transform.localRotation = rotation;
		/* if (m_isUsingGyro)
        {
		camParent.transform.eulerAngles = Vector3(90,90,0);
			print("USING GYRO");
			Quaternion rotation = new Quaternion();

            Vector3 angles = Input.gyro.attitude.eulerAngles;
			rotation.eulerAngles = new Vector3(angles.x, angles.y, angles.z);
			transform.rotation = rotation;// * Quaternion.AngleAxis(webcamTexture.videoRotationAngle, Vector3.up);
		} else {
			
			Quaternion rotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
			this.transform.localRotation = rotation;
		} 
		*/
    }
/*
	void OnGUI()
	{
		if( GUI.Button( new Rect(0,50,50,50), "switch" ))
		{
			
			webcamTexture.Stop();
			if (devices.Length >1)
			webcamTexture.deviceName = (webcamTexture.deviceName == devices[0].name) ? devices[1].name : devices[0].name;
			
			webcamTexture.Play();
		}
	}*/

}