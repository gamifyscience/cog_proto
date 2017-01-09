using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class buttonGo : MonoBehaviour {

	public Button ButtonGo;

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
		ButtonGo.interactable = !ButtonGo.interactable;	
	}

	public void PressButtonGo () 
	{
		if (ButtonGo.interactable)
		{
			msManager.TriggerEvent( "BtnStartToggle");
			msManager.TriggerEvent( "SpawnBox" );
			Debug.LogError (this.gameObject.name + " triggered Go button");
		}
	}


}
