using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBelt : MonoBehaviour {
	public float scrollSpeed = 0.25F;
	public Renderer rend;
	private bool moving;

	void Start() {
		rend = GetComponent<Renderer>();
		moving = true;
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
		print ("belt moving");
		moving = true;
	}

	void StopMoving(){
		moving = false;
	}

	void Update() {
		if (moving) {
			var scrollPos = rend.material.GetTextureOffset ("_MainTex").y;
			if (scrollPos < 1f) {
				float offset = scrollPos + scrollSpeed;
				rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, offset));
			} else {
				rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, 0));
			}
		}
	}
}
