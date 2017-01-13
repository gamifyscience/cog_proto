using UnityEngine;
using System.Collections;

public class BugReticule : MonoBehaviour
{
    Material material = null;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;

        BugTargeting.Instance.OnTargetingChanged += OnTargetingChanged;

        // Start with a red reticule. We'll get an event if we're
        // actually pointing at something
        material.color = Color.red;
    }

    private void OnDestroy()
    {
        BugTargeting.Instance.OnTargetingChanged -= OnTargetingChanged;
    }

    private void OnTargetingChanged(GameObject oldTarget, GameObject newTarget, BugTargeting.eTargetingState oldState, BugTargeting.eTargetingState newState)
    {
        switch (newState)
        {
            case BugTargeting.eTargetingState.Targeted:
                material.color = Color.green;
                break;
            case BugTargeting.eTargetingState.BarelyTargeted:
                material.color = Color.yellow;
                break;
            case BugTargeting.eTargetingState.Untargeted:
                material.color = Color.red;
                break;
        }

    }

    void TargetAcquired()
    {
        material.color = Color.green;
    }

    void TargetOff()
    {
        // We're not looking at the bug anymore, so start tweening the reticule
        // to red.
        material.color = Color.red;
    }
}
