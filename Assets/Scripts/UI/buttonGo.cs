using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.UI;
using TouchScript;
using TouchScript.Gestures;

public class buttonGo : MonoBehaviour {

	public Button ButtonGo;
	public GameObject Panel;
	public GameObject ScorePanel;

    private void Start()
    {
       msManager.StartListening("DestroyBox", DestroyBox);
    }

	private void OnEnable ()
	{	
		//if (FlickGesture.flickedinvoker != null) {
		GetComponent<FlickGesture>().Flicked += OnFlick;

		msManager.StartListening("LevelComplete", LevelComplete);

	}

	public void OnFlick (object sender, System.EventArgs e)
	{
		msManager.TriggerEvent ("Grab");
	}

	private void OnDisable()
	{
		if (TouchManager.Instance != null) {
			GetComponent<FlickGesture>().Flicked -= OnFlick;
		}
	}

	public void PressButtonGo () 
	{
		if (ButtonGo.interactable)
		{
			msManager.TriggerEvent( "SpawnBox" );
            ButtonGo.interactable = false;
			Panel.SetActive(false);
		}
	}

    void DestroyBox()
    {
       // ButtonGo.interactable = true;
    }

	void LevelComplete()
	{
		ScorePanel.SetActive(true);
	}
}
