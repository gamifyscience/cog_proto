using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class buttonStop : MonoBehaviour {

	public Button ButtonStop;

	public void PressButtonStop()
	{
		if (ButtonStop.interactable)
		{
			msManager.TriggerEvent( "Grab" );
			Debug.LogError (this.gameObject.name + " triggered Stop button");

			//temp
			msManager.TriggerEvent( "LevelComplete" );
		}
	}
}
