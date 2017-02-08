using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hidePanel : MonoBehaviour {

	public GameObject panel;
	public Button btn;  //script trigger this button


	// Use this for initialization
	void Awake () {

		msManager.StartListening ("Targeted", Targeted);
		msManager.StartListening ("Untargeted", Untargeted);

	}


	public void Targeted()
	{
		this.panel.SetActive (true);

			//if (DroneTargeting.Instance.HasTarget ())

		Button thisBtn = btn.GetComponent<Button>();
		thisBtn.onClick.Invoke ();
			print ("you pressed that button = magic");

	}

	public void Untargeted()
	{
		this.panel.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		print ("updating UI");
		if (!DroneTargeting.Instance.HasTarget ())
			Untargeted ();
	}

}