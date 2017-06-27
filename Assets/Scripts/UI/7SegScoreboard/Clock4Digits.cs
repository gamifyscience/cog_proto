using UnityEngine;
using System.Collections;

public class Clock4Digits : MonoBehaviour {

	public string text = "00";
	public Color onColor = Color.red;
	public Color offColor = Color.black;

	private GameObject displays = null;
	private GameObject points = null;

	void Start ()
	{
		displays = transform.Find("DisplayContainer").gameObject;
		points = transform.Find("Display2Points").gameObject;
	}

	void Update ()
	{
		//if(text.Length >= 5) text = "00:01";

		displays.GetComponent<ContainerDisplay7Seg>().onColor = onColor;
		displays.GetComponent<ContainerDisplay7Seg>().offColor = offColor;
		displays.GetComponent<ContainerDisplay7Seg>().text = text.Substring(0,2) + text.Substring(3,2);

		points.GetComponent<Display2Point>().onColor = onColor;
		points.GetComponent<Display2Point>().offColor = offColor;
		points.GetComponent<Display2Point>().on = text[2] == ':' ? true : false; 
	}
}
