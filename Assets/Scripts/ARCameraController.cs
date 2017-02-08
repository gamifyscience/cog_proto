using UnityEngine;
using System.Collections;

// Uses the phone's gyroscope to change the camera's rotation.
public class ARCameraController : MonoBehaviour
{
    private bool m_isUsingGyro = true;

	public GameObject webcamPlane;
	GameObject camParent;

    void Start()
	{
		/// for movement in real space
		Input.gyro.enabled = true;

		if (Application.isMobilePlatform) {
		camParent = new GameObject ("CamParent");
		camParent.transform.position = this.transform.position;
		this.transform.parent = camParent.transform;
		camParent.transform.Rotate (Vector3.right, 90);
		}

		WebCamTexture webcamTexture = new WebCamTexture ();
		webcamPlane.GetComponent<MeshRenderer> ().material.mainTexture = webcamTexture;
		webcamTexture.Play ();

        // If there's no gyroscope support, no Unity Remote, and we're in the editor, use
        // mouselook instead.
#if UNITY_EDITOR
        if (!SystemInfo.supportsGyroscope && !UnityEditor.EditorApplication.isRemoteConnected)
        {
            gameObject.AddComponent<SimpleSmoothMouseLook>();
            m_isUsingGyro = false;
        }
#endif
    }

    void Update()
    {
       
        if (m_isUsingGyro)
        {
			Quaternion rotation = new Quaternion();

            Vector3 angles = Input.gyro.attitude.eulerAngles;
			rotation.eulerAngles = new Vector3(-angles.x, -angles.y, angles.z);
            transform.rotation = rotation;
		} else {
			Quaternion rotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
			this.transform.localRotation = rotation;
		}
    }
}