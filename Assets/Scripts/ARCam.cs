using UnityEngine;
using System.Collections;

public class ARCam : MonoBehaviour
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

        //ray from the camera for detenction of objects
        RaycastHit hit;
        var ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * 84, Color.yellow);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
                msManager.TriggerEvent("TargetAcquired");
        }
        else
        {
            msManager.TriggerEvent("TargetOff");
        }
    }
}