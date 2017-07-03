using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class msManager : MonoBehaviour
{

    //  public delegate void ButtonHandler( bool isPressGo );
    //	public static event ButtonHandler onPressGo;

    private Dictionary<string, UnityEvent> eventDictionary;

    private static msManager eventManager;

    public static msManager instance
    {
        get
        {
            if (!eventManager)
            {
                eventManager = FindObjectOfType(typeof(msManager)) as msManager;

                if (!eventManager)
                {
                    Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                }
                else
                {
                    eventManager.Init();
                    //Debug.LogError ("You started an Event Manager");
                }
            }

            return eventManager;
        }
    }

    void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<string, UnityEvent>();
        }
    }

    public static void StartListening(string eventName, UnityAction listener)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.AddListener(listener);

        }
        else
        {
            thisEvent = new UnityEvent();
            thisEvent.AddListener(listener);
            instance.eventDictionary.Add(eventName, thisEvent);
			//if (Application.isEditor)
				//Debug.LogError  ("[msManager] An event was created: " + listener.Method);
        }

    }

    public static void StopListening(string eventName, UnityAction listener)
    {
        if (eventManager == null) return;
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.RemoveListener(listener);
        }
    }

    public static void TriggerEvent(string eventName)
    {
        UnityEvent thisEvent = null;
        if (instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke();
           // Debug.Log("I heard you say " + eventName);
        }
        else
        {
            	Debug.LogError ("You called " + eventName + " but it was lost, you may need to make an active UnityEvent");
            thisEvent.Invoke();
        }
    }
}
