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
			//setup the number list so it isn't empty
		Button thisBtn = btn.GetComponent<Button> ();
		thisBtn.onClick.Invoke ();
	}

	void onEnable()
	{
		msManager.StartListening ("Targeted", Targeted);
		msManager.StartListening ("Untargeted", Untargeted);
	}

	void onDisable()
	{
		msManager.StopListening ("Targeted", Targeted);
		msManager.StopListening ("Untargeted", Untargeted);
	}

	void Start()
	{
		if (!DroneTargeting.Instance.HasTarget ())
			Untargeted ();
	}

	public void Targeted()
	{
		if (this.panel.activeSelf == false) {

			this.panel.SetActive (true);

			Button thisBtn = btn.GetComponent<Button> ();
			thisBtn.onClick.Invoke ();
		}
	}

	public void BarelyTargeted()
	{
		//this.panel.SetActive (false);
	}


	public void Untargeted()
	{
		this.panel.SetActive (false);
	}

}