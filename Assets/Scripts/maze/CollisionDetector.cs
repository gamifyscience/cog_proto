using UnityEngine;
using System.Collections;

public class CollisionDetector : MonoBehaviour {

	//A new variable named timer.
	// Contains the timing class I made.
	Timer timer;
	bool Colliderdone;
//	TouchPhase touch;
	
	//This begins the timing process.
	void Start () {
		timer = new Timer();
		Colliderdone = false;
	}
		
	//OnGUI is called every frame.
	// This just makes a box that shows the time.
	// You can delete this and use whatever.
	void OnGUI () {
		//Only try to get the time if the timer isn't null.
		// If it is null, we can't get time from it
		//  because it doesn't exist!
		if(timer != null)
		{
			//Make a new GUI Box.
			// Inside, show the time (which is an integer)
			// We add +"" to make it a string.
			// It's the same as .toString()
			GUILayout.Box(timer.getTime()+"");
		}
	}
	
	//We're going to start the timer once we move
	// And NOT before.
	//This is a simple true/false variable to store that.
	bool moved = false;
	
	//Called every frame (basically a loop).
	// In this function, we just want to wait for a move
	//  To be made. Then we start the timer, and don't use this
	//   function ever again.
	void Update()
	{
		//Did we press the left/right arrow keys?
		// If so, we record that data into [delta].
		// That time is multiplied by [Time.deltaTime].
		// This just normalizes the data.
		// Without it, the [delta] variable would be dependant on how
		// quick the computer's frame rate is.
		float delta = Input.GetAxis("Horizontal")*Time.deltaTime;
		//Translate (move) this transform (the gameObject) by the amount.
		// We go to the right, multiplied by the [delta].
		// Note the delta can be negative or positive.
		//edit:looking for on click
				//transform.Translate(Vector3.right*delta);
//		if (touch == touch.Moved) {
//			print ("touch was detected");
//			moved = true;
//		}
		//If we haven't moved in any of the past frames BUT
		// the current frame has some (non-zero) movement,
		// then that means we have moved.
		if(moved == false && delta != 0)
		{
			//print ("touch was enough");
			//Set [moved] to true
			// This means the above line (moved == false)
			// will forevermore be untrue. (true == false) -> false
			// We don't need to check if we moved again anyways.
			moved = true;
			//Start the timer by using timer.startTimer().
			timer.startTimer();
		}
	}
	
	//On trigger enter.
	//
	//Setup in Editor: 
	//
	//@Moving Object
	// Add this class to the [moving object].
	//  Add a rigidbody to that object.
	//   Make sure {Gravity} = false.
	//   and {Kinematic} = false.
	//  Use a regular collider.
	//@End GameObject
	// Make sure the [end object] has a collider.
	//  Set [end]'s {trigger} = true.
	//
	// This setup makes [movingObj] collide with walls and stuff (as usual)
	// However, the endObject is a trigger, which means stuff can move through it,
	//  but an event is still sent.
	//
	// When the [movingObj] hits the trigger, OnTriggerEnter is called.
	// The parameter, [other], is the collider script of the end object.
	void OnTriggerEnter(Collider other)
	{
		//Stops the timer.
		// This might get called multiple times
		//  if the triggers hit over and over, but it will be ignored
		//  by the timer code.
		Colliderdone = true;
		//there is a check to see if this has been hit, it starts as false at init.

		if (!Colliderdone)
		timer.stopTimer();
	
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
