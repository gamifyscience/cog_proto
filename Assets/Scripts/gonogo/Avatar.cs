using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems; 

public class Avatar : MonoBehaviour {

	public GameObject AvatarGrab;
	public Animator Avatar_a;

	// Use this for initialization
	void Start () {
		msManager.StartListening ("aiGrab", aiGrab);
		msManager.StartListening ("ResetScore", ResetScore);
		msManager.StartListening ("ItemSpawned", ItemSpawned);
		Avatar_a = GetComponent<Animator>();

	}


	void aiGrab()
	{
		Avatar_a.SetTrigger("Grab"); 

	}

	void ItemSpawned()
	{
		Avatar_a.SetTrigger("GrabReady");

	}

	void ResetScore()
	{
		Avatar_a.SetTrigger("Cry");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
