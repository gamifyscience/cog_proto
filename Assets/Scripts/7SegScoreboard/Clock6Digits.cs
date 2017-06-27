using UnityEngine;
using System.Collections;

public class Clock6Digits : MonoBehaviour {

	public string text = "12:34:56";
	public Color onColor = Color.red;
	public Color offColor = Color.black;

	private GameObject displays = null;
	private GameObject  points1= null;
	private GameObject points2 = null;

	void Start ()
	{
		displays = transform.Find("DisplayContainer").gameObject;
		points1 = transform.Find("Display2Points1").gameObject;
		points2 = transform.Find("Display2Points2").gameObject;
	}

	void Update ()
	{
		if(text.Length != 8) text = "12:34:56";

		displays.GetComponent<ContainerDisplay7Seg>().onColor = onColor;
		displays.GetComponent<ContainerDisplay7Seg>().offColor = offColor;
		displays.GetComponent<ContainerDisplay7Seg>().text = text.Substring(0,2) + text.Substring(3,2) + text.Substring(6,2);

		points1.GetComponent<Display2Point>().onColor = onColor;
		points1.GetComponent<Display2Point>().offColor = offColor;
		points1.GetComponent<Display2Point>().on = text[2] == ':' ? true : false;

		points2.GetComponent<Display2Point>().onColor = onColor;
		points2.GetComponent<Display2Point>().offColor = offColor;
		points2.GetComponent<Display2Point>().on = text[5] == ':' ? true : false;
	}
}
