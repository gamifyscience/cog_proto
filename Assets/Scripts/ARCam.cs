using UnityEngine;
using System.Collections;

public class ARCam : MonoBehaviour {
	public int top;
	public int side;

    private Camera cam;

    void Start () {
		/// for the ray trace from camera
		cam = GetComponent<Camera>();
		/// for movement in real space
		Input.gyro.enabled = true;

        // If there's no gyroscope support, no Unity Remote, and we're in the editor, use
        // mouselook instead.
#if UNITY_EDITOR
        if (!SystemInfo.supportsGyroscope && !UnityEditor.EditorApplication.isRemoteConnected)
        {
            gameObject.AddComponent<SimpleSmoothMouseLook>();
        }
#endif
    }

	void Update () {
		Quaternion rotation = new Quaternion();

        Vector3 angles = Input.gyro.attitude.eulerAngles;
        rotation.eulerAngles = new Vector3(-angles.x, -angles.y, angles.z);
        transform.rotation = rotation;

		//ray from the camera for detenction of objects
		top  = cam.pixelWidth / 2;
		side = cam.pixelHeight / 2;
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