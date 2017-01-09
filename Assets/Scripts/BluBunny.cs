using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems; 

public class BluBunny : MonoBehaviour {

	public GameObject BluBunnyGrab;
	public Animator BluBunny_a;

	// Use this for initialization
	void Start () {
		msManager.StartListening ("aiGrab", aiGrab);
		msManager.StartListening ("ResetScore", ResetScore);
		msManager.StartListening ("ItemSpawned", ItemSpawned);
		BluBunny_a = GetComponent<Animator>();

	}


	void aiGrab()
	{
		BluBunny_a.SetTrigger("Grab"); 

	}

	void ItemSpawned()
	{
		BluBunny_a.SetTrigger("GrabReady");

	}

	void ResetScore()
	{
		BluBunny_a.SetTrigger("Cry");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
