using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject m_bugPrefab;
    public int kMinBugCount = 2;
    public int kMaxBugCount = 6;

    private void Awake()
    {
        int numBugs = Random.Range(kMinBugCount, kMaxBugCount);

        // Spawn some bugs near the world origin.
        for (int i = 0; i < numBugs; ++i)
        {
            Vector3 pos = RandomVector3(-10f, 10f);

            SpawnBug(pos);
        }
    }

    private static Vector3 RandomVector3(float min, float max)
    {
        return new Vector3(
            Random.Range(min, max),
            Random.Range(min, max),
            Random.Range(min, max)
            );
    }

    // Spawns a single bug.
    private void SpawnBug(Vector3 position)
    {
        GameObject bug = Instantiate(m_bugPrefab, position, Quaternion.identity) as GameObject;
    }
}