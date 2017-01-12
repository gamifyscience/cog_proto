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
        var material = gameObject.GetComponent<Renderer>().material;
        material.SetFloat("cutoff", 0f);
	}

	void TargetOff ()
	{
        var material = gameObject.GetComponent<Renderer>().material;

        // TODO: slowly tween to 1f
        material.SetFloat("cutoff", 1f);
    }
}
