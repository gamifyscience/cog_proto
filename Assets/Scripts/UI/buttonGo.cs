using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class buttonGo : MonoBehaviour {

	public Button ButtonGo;

	public void PressButtonGo () 
	{
		if (ButtonGo.interactable)
		{
			msManager.TriggerEvent( "SpawnBox" );
		}
	}
}
