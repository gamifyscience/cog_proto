using UnityEngine;
using System.Collections;

public class ARCam : MonoBehaviour {
	public Camera camera;
	public int top;
	public int side;

	void Start () {
		/// for the ray trace from camera
		camera = GetComponent<Camera>();
		/// for movement in real space
		Input.gyro.enabled = true;
	}

	// Update is called once per frame
	void Update () {
		Quaternion rotation = new Quaternion();
		Vector3 angles = Input.gyro.attitude.eulerAngles;
		rotation.eulerAngles = new Vector3(-angles.x, -angles.y, angles.z);
		transform.rotation = rotation;

		//ray from the camera for detenction of objects
		top  = camera.pixelWidth / 2;
		side = camera.pixelHeight / 2;
		RaycastHit hit;
		Ray ray = GetComponent<Camera>().ScreenPointToRay(new Vector3(top, side, 0));
		Debug.DrawRay(ray.origin, ray.direction * 84, Color.yellow);

		if (Physics.Raycast (ray, out hit))
		{
			if (hit.collider != null)
				msManager.TriggerEvent ("TargetAcquired");
		} else {
			msManager.TriggerEvent ("TargetOff");
		}


	}


}