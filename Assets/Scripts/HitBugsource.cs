using UnityEngine;
using System.Collections;

public class HitBugsource : MonoBehaviour {
	//public GameObject retical;

	// Use this for initialization
	void Start () {
		//GameObject retical = this.gameObject;
		//retical.transform.position = GetComponent<Camera>().ScreenToWorldPoint( new Vector3(Screen.width/2, Screen.height/2, Camera.main.nearClipPlane) );
		msManager.StartListening ("TargetAcquired", TargetAcquired);
		msManager.StartListening ("TargetOff", TargetOff);
	}


	void TargetAcquired()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.green;
	}

	void TargetOff ()
	{
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
