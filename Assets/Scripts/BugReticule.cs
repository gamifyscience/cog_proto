using UnityEngine;
using System.Collections;

public class BugReticule : MonoBehaviour
{
    // Are we tweening the reticule color from green to red?
    private bool m_isTweening = false;
    private float m_tweenStartTime = 0f;
    Material material = null;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;

        msManager.StartListening("TargetAcquired", TargetAcquired);
        msManager.StartListening("TargetOff", TargetOff);

        // Start with a red reticule. We'll get the "TargetAcquired" event if we're
        // actually pointing at something
        material.SetFloat("cutoff", 1f);
    }

    void Update()
    {
        if (m_isTweening)
        {
            float timeElapsed = Time.time - m_tweenStartTime;

            material.SetFloat("cutoff", timeElapsed);

            if (timeElapsed >= 1f)
                m_isTweening = false;
        }
    }

    void TargetAcquired()
    {
        material.SetFloat("cutoff", 0f);
    }

    void TargetOff()
    {
        // We're not looking at the bug anymore, so start tweening the reticule
        // to red.
        m_isTweening = true;
        m_tweenStartTime = Time.time;
    }
}
