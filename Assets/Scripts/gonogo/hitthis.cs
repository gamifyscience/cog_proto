using UnityEngine;
using System.Collections;

public class hitthis : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider col)
	{
		//print ("Claw hit: part " + this.gameObject.name + ": " + col.GetComponent<Collider>().name);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
