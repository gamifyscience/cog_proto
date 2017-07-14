using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBelt : MonoBehaviour {
	public float scrollSpeed = 0.55F;
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
		moving = true;
	}

	void StopMoving(){
		moving = false;
	}

	void Update() {
		if (moving) {
			var scrollPos = rend.material.GetTextureOffset ("_MainTex").y;
			//animate the belt texture for the illusion of moving.
			//move at a consistance rate, not frame based
			float speed = scrollSpeed * Time.deltaTime;
			if (scrollPos < 1f) {
				float offset = scrollPos + speed;
					rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, offset));
				} else {
					rend.material.SetTextureOffset ("_MainTex", new Vector2 (0, 0));
				}
		}
	}
}
