using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigitTimer : MonoBehaviour {

	Timer timer;
	private string Counter;
	public int MaxTime;

	void Start ()
	{
		timer = new Timer();
		timer.startTimer();
		timer.StartCountDown (MaxTime);
	}
		

	void Update ()
	{
		if (timer.countDown () > 0)
			Counter = timer.countDown() + "";
		
		if (Counter.Length < 2)
				Counter = "0" + Counter;
		
		string text = "00" + ":" + Counter;
	
		GetComponent<Clock4Digits>().text = text;
	}
		
	public void RecordTime()
	{
		timer.stopTimer ();
		print("Stoptime " + Time.time);
	}


	public class Timer
	{
		private int startTime;
		private int stopTime;
		private int countDownTime;
		private bool isRunning = false;

//instance
		//public Timer(){}

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

		public int countDown()
		{
			var timePassed = getTime ();
			return countDownTime - timePassed;

		}

		public void startTimer()
		{
			startTime = (int)Time.time;
			isRunning = true;
			Debug.Log("Timer Start" + startTime);
		}

		public void StartCountDown(int MaxTime)
		{
			countDownTime = MaxTime;
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
