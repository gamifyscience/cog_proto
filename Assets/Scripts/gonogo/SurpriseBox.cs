using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurpriseBox : MonoBehaviour {

//	public static SurpriseBox Instance { get; private set; }
	//public Animator SpawnedBox_a;
	public Animator SpawnedBox_a;

	//animate the platform that moves the box on and off screen.
	//public GameObject Conveyor;
	//public Animator Conveyor_a; //this is a animation trigger-object controller

	public GameObject[] active_inactive;
	public Transform pickup_position;
	public Transform middle_position;
	public Transform end_position;

	public BoxSpawner m_spawner;

	public GameObject spawned_item;

	public float move_time = 1.0f;
	public float wait_time = 0.6f;
	public float speed = 0.5f;
    // How long should the box wait in place before opening? (We'll choose a random
    // number between these two values.)
    private const float kMinPauseBeforeOpen = 0.1f;
    private const float kMaxPauseBeforeOpen = 1.5f;

	private bool exitnow;
	private bool readynow;

    void Start () 
	{ 
		exitnow = false; //set when the Box has been open for wait_time
		readynow = false; //setup when a box is spawn
		StartCoroutine ( BoxRoutine () );
	}


	IEnumerator BoxRoutine () 
	{
		// find wait and end points
		Animator SpawnedBox_a = Animator.FindObjectOfType<Animator>();
		BoxSpawner m_spawner = BoxSpawner.FindObjectOfType<BoxSpawner>();

 		middle_position = GameObject.Find("ActionPoint").transform;
 		end_position = GameObject.Find("EndPoint").transform;
		pickup_position = GameObject.Find("pickup_position").transform;

		//move toward wait point
		movetoAction( middle_position );
		yield return new WaitForEndOfFrame ();

		// wait until the box reaches the center of the screen
		yield return new WaitForSeconds(move_time);

        // dalay a random amount of time before opening the box
        float delay_time = Random.Range(kMinPauseBeforeOpen, kMaxPauseBeforeOpen);
		yield return new WaitForSeconds(delay_time);

        // open the box and spawn an item from the array
		m_spawner.SpawnItem();
        SpawnedBox_a.SetTrigger("openbox");

		// pause to let you grab the item
		yield return new WaitForSeconds(wait_time);

		//Tell the scene you ran out of time
		//Close the Box
		msManager.TriggerEvent ("NoInteraction");
		SpawnedBox_a.SetTrigger("closebox");
		msManager.TriggerEvent( "StartMoving" );
		yield return new WaitForEndOfFrame ();
		//move towards end point and remove box
		movetoExit();
		yield return new WaitForEndOfFrame ();

		// pause to cleanup the box
		yield return new WaitForSeconds(move_time);

		//	TBD if we are still playing and != round over
		//psuedo if (count is maxCount) msManager.TriggerEvent ("LevelComplete");


	}

	void movetoAction(Transform middle_position)
	{
		//calculate time to wait for box to arrive at action point
		float timetotarget = Vector3.Distance(transform.position, middle_position.position);
		float timetowait = timetotarget / (10*speed) ;
		//Debug.LogError (timetowait + "/ distance "+ timetotarget);
		move_time = timetowait;
		readynow = true; //update will move the box to the action point

		/*iTween.MoveTo(
			this.gameObject, 
			iTween.Hash("position", middle_position, 
				"time", move_time, 
				"easetype", iTween.EaseType.linear,
				"oncomplete", "m_spawner.SpawnItem")
		); */
	}

	void movetoExit()
	{
		exitnow = true;
		//Debug.LogError (end_position.transform.position + " end, " + this.transform.position + "start");
	/*	iTween.MoveTo(
			this.gameObject, 
			iTween.Hash("position", end_position, 
				"time", move_time, 
				"easetype", iTween.EaseType.linear,
				"oncomplete", "CleanUp" )
		); */
	}


	void Update()
	{
		if (exitnow == true) {
			//Debug.LogError ("Box Loc: " + transform.position.ToString());
			transform.position = Vector3.MoveTowards (transform.position, end_position.position, speed);
			if (transform.position == end_position.position) {
				CleanUp ();
				exitnow = false;
			}
		} else if (readynow == true) {
			transform.position = Vector3.MoveTowards (transform.position, middle_position.position, speed);
			if (transform.position == middle_position.position) {
				msManager.TriggerEvent( "StopMoving" );
				readynow = false;
			}
		}
	
	}

	void CleanUp ()
	{
		//Conveyor_a.SetBool("moving", false);
		//msManager.TriggerEvent( "StopMoving" );
		msManager.TriggerEvent( "DestroyBox" );
		Destroy(this.gameObject, move_time);

	}

}
