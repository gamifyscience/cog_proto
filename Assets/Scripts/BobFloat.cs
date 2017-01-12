using UnityEngine;
using System.Collections;

public class BobFloat : MonoBehaviour
{
    float originalY;
    float originalX;
    public float floatStrength = 1; // You can change this in the Unity Editor to 
                                    // change the range of y positions that are possible.
    
    // We'll start each item with a random time offset. This is to ensure
    // that the all items don't bob in perfect sync with each other.
    public float m_timeOffset;

    void Awake()
    {
        originalY = this.transform.position.y;
        m_timeOffset = Random.Range(-2f, 2f);
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, originalY + ((float)Mathf.Sin(Time.time + m_timeOffset) * floatStrength),
                transform.position.z);
    }
}
