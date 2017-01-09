using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class buttonStop : MonoBehaviour {

	public Button ButtonStop;

	void OnEnable ()
	{
		msManager.StartListening ("BtnStartToggle", BtnStartToggle);
	}
		
	void onDisable ()
	{
		msManager.StopListening ("BtnStartToggle", BtnStartToggle);
	}
		
	public void BtnStartToggle() 
	{ 
		ButtonStop.interactable = !ButtonStop.interactable;	
	}

	public void PressButtonStop()
	{
		if (ButtonStop.interactable)
		{
			msManager.TriggerEvent( "BtnStartToggle");
			msManager.TriggerEvent( "Grab" );
			Debug.LogError (this.gameObject.name + " triggered Stop button");

			//temp
			msManager.TriggerEvent( "LevelComplete" );
		}
	}

	void Start ()
	{
		
	}
	void Update ()
	{
		
	}
		
}
