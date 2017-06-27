using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class SetTimerCountUp : MonoBehaviour {

	Timer timer;


	void Start ()
	{
		timer = new Timer();
		timer.startTimer();
	}

	void Update ()
	{
		string text = System.DateTime.Now.Hour.ToString("00") + ":" +System.DateTime.Now.Minute.ToString("00");

		if(System.DateTime.Now.Millisecond % 1000 > 500) text = text.Substring(0,2) + ' ' + text.Substring(3,2);

		GetComponent<Clock4Digits>().text = text;
	}

	public class Timer
	{
		int startTime;
		int stopTime;
		bool isRunning = false;
		public Timer(){}
		public int getTime()
		{
			if(isRunning)
			{
				return (int)Time.time-startTime;
			}
			else
			{
				return stopTime-startTime;
			}
		}
		public void startTimer()
		{
			startTime = (int)Time.time;
			isRunning = true;
			Debug.Log("Timer Start" + startTime);
		}
		public void stopTimer()
		{
			if(isRunning)
			{
				stopTime = (int)Time.time;
				isRunning = false;
				Debug.Log("Stopped Timer at "+getTime()+" seconds.");
			}
		}
	}

}
