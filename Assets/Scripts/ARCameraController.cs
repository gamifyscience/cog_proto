using UnityEngine;
using System.Collections;

// Uses the phone's gyroscope to change the camera's rotation.
public class ARCameraController : MonoBehaviour
{
    private bool m_isUsingGyro = true;

    void Start()
    {
        /// for movement in real space
        Input.gyro.enabled = true;

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
        Quaternion rotation = new Quaternion();

        if (m_isUsingGyro)
        {
            Vector3 angles = Input.gyro.attitude.eulerAngles;
            rotation.eulerAngles = new Vector3(-angles.x, -angles.y, angles.z);
            transform.rotation = rotation;
        }
    }
}