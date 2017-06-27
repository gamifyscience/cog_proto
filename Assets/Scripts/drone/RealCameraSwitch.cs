using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealCameraSwitch : MonoBehaviour {

	WebCamTexture webCamTexture;
	WebCamDevice[] devices;

	void Start() 
	{
		devices = WebCamTexture.devices;
		webCamTexture = new WebCamTexture();
		webCamTexture.deviceName = devices[0].name;
		webCamTexture.Play();
	}

	void OnGUI()
	{
		if( GUI.Button( new Rect(0,0,100,100), "switch" ))
		{
			webCamTexture.Stop();
			webCamTexture.deviceName = (webCamTexture.deviceName == devices[0].name) ? devices[1].name : devices[0].name;
			webCamTexture.Play();
		}
	}

	/*   Quaternion quatMult = Quaternion.identity;
       
        if (Screen.orientation == ScreenOrientation.PortraitUpsideDown) {
             quatMult = new Quaternion(0f,0f,0.7071f,-0.7071f);
        } else if (Screen.orientation == ScreenOrientation.Portrait) {
             quatMult = new Quaternion(0f,0f,-0.7071f,-0.7071f);
        } else if (Screen.orientation == ScreenOrientation.LandscapeRight) {
            quatMult = new Quaternion(0f,0f,0f,1f);
       } else if (Screen.orientation == ScreenOrientation.LandscapeLeft) {
            quatMult = new Quaternion(0f,0f,1f,0f);
      }
  */
}
