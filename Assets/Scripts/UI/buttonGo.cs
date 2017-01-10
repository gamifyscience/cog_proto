using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;

public class buttonGo : MonoBehaviour {

	public Button ButtonGo;

    private void Start()
    {
        msManager.StartListening("DestroyBox", DestroyBox);
    }

	public void PressButtonGo () 
	{
		if (ButtonGo.interactable)
		{
			msManager.TriggerEvent( "SpawnBox" );
            ButtonGo.interactable = false;
		}
	}

    void DestroyBox()
    {
        ButtonGo.interactable = true;
    }
}
