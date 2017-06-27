using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneSpawner : MonoBehaviour
{
    public GameObject m_dronePrefab;
    public int kMinDroneCount = 4;
    public int kMaxDroneCount = 6;

    // These define how far away from the camera the drones can spawn.
    public float kMinDroneDistance = 25f;
    public float kMaxDroneDistance = 60f;
	public float kMinDroneHeight = -15f;
	public float kMaxDroneHeight = 25f;

    private void Awake()
    {
		int numDrones = Random.Range(kMinDroneCount, kMaxDroneCount);
        Vector3 camPos = Camera.main.transform.position;

        // Spawn some drones near the world origin.
        for (int i = 0; i < numDrones; ++i)
        {
			//float thisz = Random.Range (kMinDroneDistance, kMaxDroneDistance);
			float thisy = Random.Range (kMinDroneHeight, kMaxDroneHeight);

            // TODO: ensure that drones can't spawn too close to one another.
			Vector3 pos = GetRandomDronePosition(camPos, thisy, kMinDroneDistance, kMaxDroneDistance );

            SpawnDrone(pos);
        }
    }

    // minDistance and maxDistance signify the range of possible distances from the origin.
    private static Vector3 GetRandomDronePosition(Vector3 origin, float yValue, float minDistance, float maxDistance)
    {
        // Get a random direction vector
        Vector3 direction = RandomUtils.GetNormalizedVector();
        // Extend the vector out to a random distance

        direction *= Random.Range(minDistance, maxDistance);
        // Start from the specified origin
		direction[1] = yValue;
		//print (direction);
        return direction + origin;
    }

    // Spawns a single drone.
    private void SpawnDrone(Vector3 position)
    {
        Instantiate(m_dronePrefab, position, Quaternion.identity);
    }
}