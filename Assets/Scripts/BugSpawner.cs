using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject m_bugPrefab;
    public int kMinBugCount = 2;
    public int kMaxBugCount = 6;

    // These define how far away from the camera the bugs can spawn.
    public float kMinBugDistance = 5f;
    public float kMaxBugDistance = 15f;

    private void Awake()
    {
        int numBugs = Random.Range(kMinBugCount, kMaxBugCount);
        Vector3 camPos = Camera.main.transform.position;

        // Spawn some bugs near the world origin.
        for (int i = 0; i < numBugs; ++i)
        {
            // TODO: ensure that bugs can't spawn too close to one another.
            Vector3 pos = GetRandomBugPosition(camPos, kMinBugDistance, kMaxBugDistance);

            SpawnBug(pos);
        }
    }

    // minDistance and maxDistance signify the range of possible distances from the origin.
    private static Vector3 GetRandomBugPosition(Vector3 origin, float minDistance, float maxDistance)
    {
        // Get a random direction vector
        Vector3 direction = RandomUtils.GetNormalizedVector();

        // Extend the vector out to a random distance
        direction *= Random.Range(minDistance, maxDistance);

        // Start from the specified origin
        return direction + origin;
    }

    // Spawns a single bug.
    private void SpawnBug(Vector3 position)
    {
        Instantiate(m_bugPrefab, position, Quaternion.identity);
    }
}