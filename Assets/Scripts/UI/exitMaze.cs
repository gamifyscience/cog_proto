using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitMaze : MonoBehaviour {

	public void OnTriggerEnter (Collider other)
	{
		GetComponent<loadlevel>().ButtonClickDecoder2 ();

	}
}
