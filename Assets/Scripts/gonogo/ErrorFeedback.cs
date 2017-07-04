using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorFeedback : MonoBehaviour {

	public GameObject[] explode_fx;
	public  Transform ActionSpawnPoint;
	GameObject error_fx;
	// Use this for initialization
	void Start () {
		
	}

	void OnEnable ()
	{
		msManager.StartListening("Impulse", Impulse);
		msManager.StartListening("ResetScore", ResetScore);
		msManager.StartListening("ItemSpawned", ItemSpawned);
		msManager.StartListening("aiGrab", aiGrab);
		msManager.StartListening("LevelComplete", LevelComplete);
		msManager.StartListening("NoInteraction", NoInteraction);
		msManager.StartListening ("SpawnBox", SpawnBox);
	}

	void OnDisable() {
		
	}

	void ResetScore()
	{
		error_fx = Instantiate (explode_fx [0], ActionSpawnPoint);
		msManager.TriggerEvent("DestroyItem");
	}
	void Impulse()
	{

	}

	void ItemSpawned()
	{

	}

	void SpawnBox()
	{
		DestroyObject (error_fx);
	}

	void aiGrab()
	{

	}

	void NoInteraction()
	{

	}

	void LevelComplete()
	{

	}
	// Update is called once per frame
	void Update () {
		
	}
}
