using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SurpriseBox : MonoBehaviour {

//	public static SurpriseBox Instance { get; private set; }
	//public Animator SpawnedBox_a;
	public Animation SpawnBox_anim;
	public GameObject[] bombs_and_veggies;
	public Transform pickup_position;
	public Transform middle_position;
	public Transform end_position;

	public BoxSpawner m_spawner;

	public GameObject spawned_item;

	public float move_time = 0.4f;
	public float wait_time = 0.8f;
    // How long should the box wait in place before opening? (We'll choose a random
    // number between these two values.)
    private const float kMinPauseBeforeOpen = 0.1f;
    private const float kMaxPauseBeforeOpen = 1.5f;

    void Start () 
	{ 
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
		movetoAction( middle_position, move_time );

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
		
		//move towards end point and remove box
		movetoExit (end_position, move_time);

		// pause to cleanup the box
		yield return new WaitForSeconds(move_time);


		//	TBD if we are still playing and != round over
		//psuedo if (count is maxCount) msManager.TriggerEvent ("LevelComplete");

	}

	void movetoAction(Transform middle_position, float move_time )
	{
		iTween.MoveTo(
			this.gameObject, 
			iTween.Hash("position", middle_position, 
				"time", move_time, 
				"easetype", iTween.EaseType.linear,
				"oncomplete", "m_spawner.SpawnItem")
		);
	}

	void movetoExit(Transform end_position, float move_time)
	{
		Debug.LogError (end_position.transform + " end, " + this.transform.position + "start");
		/*while this.gameObject.transform != end_position)
		{

			transform.position = Vector3.Lerp(transform.position, waypoint.position, speed /150);
	*/
		iTween.MoveTo(
			this.gameObject, 
			iTween.Hash("position", end_position, 
				"time", move_time, 
				"easetype", iTween.EaseType.linear,
				"oncomplete", "CleanUp" )
		);
	}

	void CleanUp ()
	{
		msManager.TriggerEvent( "DestroyBox" );
		Destroy(this.gameObject, 0.8f);
	}
	
}
