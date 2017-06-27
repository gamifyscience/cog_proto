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
		//msManager.StartListening ("BarelyTargeted", BarelyTargeted);

		//setup the number list so it isn't empty
		Button thisBtn = btn.GetComponent<Button> ();
		thisBtn.onClick.Invoke ();
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