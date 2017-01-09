using UnityEngine;
using System.Collections;

public class BobFloat : MonoBehaviour {
	float originalY;
	float originalX;
	public float floatStrength = 1; // You can change this in the Unity Editor to 
									// change the range of y positions that are possible.

	void Start()
	{
		this.originalY = this.transform.position.y;
		this.originalX = this.transform.position.x;
	}

		void Update()
		{
		transform.position = new Vector3(originalX + ((float) Mathf.Sin(Time.time) * floatStrength), originalY + ((float)Mathf.Sin(Time.time) * floatStrength),
				transform.position.z);
		}
}
