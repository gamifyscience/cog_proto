using UnityEngine;
using System.Collections;

public class Display2Point : MonoBehaviour {

	public bool on = false;
	public Color onColor = Color.red;
	public Color offColor = Color.black;

	private GameObject p = null;

	void Start ()
	{
		p = transform.Find("p2").gameObject;
	}

	void Update ()
	{
		if(on) p.GetComponent<Renderer>().material.color = onColor;
		else p.GetComponent<Renderer>().material.color = offColor;
	}
}
