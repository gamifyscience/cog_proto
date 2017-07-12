using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attach this script to the camera to find out which drone, if any,
// is being targeted.
// 
// Sends events when we acquire, start to lose, or completely lose a drone.
public class DroneTargeting : MonoBehaviour
{
    public delegate void TargetingChangedDelegate(GameObject oldTarget, GameObject newTarget, eTargetingState oldState, eTargetingState newState);
    public TargetingChangedDelegate OnTargetingChanged;

    public static DroneTargeting Instance { get; private set; }
	public GameObject Player; //used for finding angle direction to drone
	public Transform Direction_img; //the direction arrow on reticule target
	protected GameObject m_closestDrone;

    private float kTargetedAngle = 5f;
    private float kBarelyTargetedAngle = 10f;

    private eTargetingState m_state = eTargetingState.Untargeted;
    private GameObject m_target = null;
    // How often should we recheck our targets?
    private const float kUpdateInterval = 0.3f;

    public enum eTargetingState
    {
        Untargeted,
        Targeted,
        BarelyTargeted,
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("Duplicate DroneTargeting detected. Destroying...");
            Destroy(Instance);
        }

        Instance = this;

        StartCoroutine(CheckTargets());
    }

    // Finds the drone that we're looking at most directly. Updates our target
    // and targeting state as necessary.
    IEnumerator CheckTargets()
    {
        while (true)
        {
            // TODO: Cache this list of drones and only update it when we
            // expect it to have changed.
            var drones = GameObject.FindGameObjectsWithTag("Drone");

            Vector3 camForward = transform.forward;
            Vector3 camPos = transform.position;
            float bestAngle = float.MaxValue;
			if (m_closestDrone)
				m_closestDrone = null;

            foreach (GameObject drone in drones)
            {
                Vector3 dronePos = drone.transform.position;
				Vector3 directionToDrone = (dronePos - camPos).normalized;

                // Angle (in degrees) between the camera's center and the vector to the drone
                float angle = Vector3.Angle(camForward, directionToDrone);

                if (angle < bestAngle)
                {
					m_closestDrone = drone; //best target and closest are the same clone btw
                    bestAngle = angle;
                }
            }

			UpdateCurrentTarget(m_closestDrone, bestAngle);

			//put a direction arrow toward closest drone
			Vector3 dir = Player.transform.InverseTransformPoint(m_closestDrone.transform.position);
			float z = Mathf.Atan2 (dir.x, dir.z) * Mathf.Rad2Deg;
			Direction_img.transform.localEulerAngles = new Vector3 (0, 0, z + 180);

            yield return new WaitForSeconds(kUpdateInterval);
        }
    }

    public void DestroyCurrentTarget()
    {
        Destroy(m_target);
        m_target = null;

		// TODO need to clear UI numbers for countsort task
    }

    public bool HasTarget()
    {
        return m_target != null;
    }

    private void UpdateCurrentTarget(GameObject target, float angle)
    {
        eTargetingState state = CalculateStateFromAngle(angle);

        if (state == eTargetingState.Untargeted)
        {
            // The target wasn't focused enough to count, so null it out
            target = null;
        }

        if (target == m_target && state == m_state)
        {
            // Nothing has changed.
            return;
        }

        if (OnTargetingChanged != null)
        {
            OnTargetingChanged(m_target, target, m_state, state);
        }

        m_state = state;
        m_target = target;
		//UpdateDirectionArrow ();

    }

    // Takes an angle from camera center and tells us whether we're looking at the target
    // directly, indirectly, or not at all.
    private eTargetingState CalculateStateFromAngle(float angle)
    {
        if (angle < kTargetedAngle)
            return eTargetingState.Targeted;
        else if (angle < kBarelyTargetedAngle)
            return eTargetingState.BarelyTargeted;
        else
            return eTargetingState.Untargeted;
    }
}