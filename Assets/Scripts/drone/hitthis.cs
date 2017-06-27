using UnityEngine;
using System.Collections;

public class hitthis : MonoBehaviour {

	public Rigidbody rbody;
	// Use this for initialization
	void Start () {
		rbody = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider col)
	{
		print ("YOU HIT SOMETHING with " + this.gameObject.name + ": " + col.GetComponent<Collider>().name);

	}

	// Update is called once per frame
	void Update () {
	
	}
}
