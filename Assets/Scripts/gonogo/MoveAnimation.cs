using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveAnimation : MonoBehaviour {

	//private GameObject Conveyor;
	public Animator Conveyor_a;
	// Use this for initialization

	void Start () {
		//GameObject Conveyor = GameObject.FindGameObjectWithTag ("Belt");
		//Conveyor_a = GetComponent<Animator> ();
		Conveyor_a.SetBool("moving", true);
	}

	void OnEnable()
	{
		msManager.StartListening ("StartMoving", StartMoving);
		msManager.StartListening ("StopMoving", StopMoving);
	}

	void OnDisable()
	{
		msManager.StopListening ("StartMoving", StartMoving);
		msManager.StopListening ("StopMoving", StopMoving);
	}

	void StartMoving(){
		Conveyor_a.SetBool("moving", true);
	}

	void StopMoving(){
		Conveyor_a.SetBool("moving", false);
	}
}
