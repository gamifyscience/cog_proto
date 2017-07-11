using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class DroneReticule : MonoBehaviour
{
    Material material = null;
	public Animator spin;// = GetComponent<Animator>();

	public GameObject[] UIPanel;

	protected GameObject m_closestDrone;

    void Start()
    {
        material = gameObject.GetComponent<Renderer>().material;
		spin = GetComponent<Animator> ();
        DroneTargeting.Instance.OnTargetingChanged += OnTargetingChanged;

        // Start with a red reticule. We'll get an event if we're
        // actually pointing at something
        material.color = Color.blue;
		spin.SetBool ("rotate", false);

		UIPanel = GameObject.FindGameObjectsWithTag("Panel");

		//UIPanel.SetValue (enabled, false);
		//UIPanel.GetEnumerator()
//		Debug.LogError (UIPanel);
    }

    private void OnDestroy()
    {
        DroneTargeting.Instance.OnTargetingChanged -= OnTargetingChanged;
		msManager.TriggerEvent ("Untargeted");
    }

    private void OnTargetingChanged(GameObject oldTarget, GameObject newTarget, DroneTargeting.eTargetingState oldState, DroneTargeting.eTargetingState newState)
    {
		//Animator spin = GetComponent<Animator>();
		//spin.Play("inner");
        switch (newState)
        {
		case DroneTargeting.eTargetingState.Targeted:
			material.color = Color.green;
			spin.SetBool ("rotate", true);
			msManager.TriggerEvent ("Targeted");
            break;
		case DroneTargeting.eTargetingState.BarelyTargeted:
			material.color = Color.blue;
			msManager.TriggerEvent ("BarelyTargeted");
            break;
		case DroneTargeting.eTargetingState.Untargeted:
			material.color = Color.red;
			spin.SetBool ("rotate", false);
			msManager.TriggerEvent ("Untargeted");
            break;
        }

    }

    void TargetAcquired()
    {
        material.color = Color.green;
		m_closestDrone = FindNearestTarget ();
		transform.position = m_closestDrone.transform.position;
		print (m_closestDrone.transform.position.ToString ());
		//spin.SetTrigger ("TargetOn");
    }

	//find nearest drone:
	GameObject FindNearestTarget()
	{
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Drone");
		GameObject targetGO = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos)
		{
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance)
			{
				targetGO = go;
				distance = curDistance;
			}
		}
		//Debug.LogError(targetGO.transform.position.ToString());
		return targetGO;
	}

    void TargetOff()
    {
        // We're not looking at the drone anymore, so start tweening the reticule
        // to red.
        material.color = Color.red;
		spin.SetBool ("rotate", false);
		msManager.TriggerEvent ("Untargeted");
		//transform.Rotate(90, 0, 0, Space.Self);
    }
}
