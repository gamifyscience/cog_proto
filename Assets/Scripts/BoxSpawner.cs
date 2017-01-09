using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class BoxSpawner : MonoBehaviour {

	//public static BoxSpawner instance;

	//value from slider for spawnertrigger
	public float threshhold;
	//Environemtn effects
	public Animator Claw_a;
	public GameObject Claw;

	//Box
	public static GameObject spawned_box;
	public Transform spawn_point;
	public GameObject SurpriseBox;

	//Items
	public GameObject[] bombs_and_veggies;	//list of items we can spawn
	public Transform pickup_point;			//target spawnpoint for the item
	public Transform pickup_position;		//where the box will open and show the item
	public float probability = 0.3f; 		//chance of getting an unwanted item
	private PickupItem m_spawnItem;			//object script of the current item


	// Use this for initialization
	void Start () 
	{
		//instance = this;

	}
	 
	void OnEnable ()
	{
		msManager.StartListening ("SpawnBox", SpawnBox);
		msManager.StartListening ("Grab", Grab);
		msManager.StartListening ("ItemSpawned", ItemSpawned);
	}


	void onDisable ()
	{
		msManager.StopListening ("SpawnBox", SpawnBox);
		msManager.StopListening ("Grab", Grab);
		msManager.StopListening ("ItemSpawned", ItemSpawned);
	}

	public void SpawnBox()
	{
		//this should be setup to repeat while enabled
		InvokeRepeating ("SpawnBoxRoutine", 0, 3);
	}

	public void Grab()
	{
		//this we stop when a grab happens
		CancelInvoke ("SpawnBoxRoutine");
	}


	// Clone a new surprise box
	public void SpawnBoxRoutine () 
	{
		
		spawn_point = GameObject.Find("SpawnPoint").transform;

		GameObject spawned_box = Instantiate 
		(
			SurpriseBox, 
			spawn_point.position, 
			Quaternion.identity
		) as GameObject;
		spawned_box.transform.eulerAngles = new Vector3 (0,0,0);
	}


	public void SpawnItem() 
	{
		//cleanup old item
		PickupItem m_spawnItem = PickupItem.FindObjectOfType<PickupItem>();
		if (m_spawnItem != null)
		{
			UserPass(m_spawnItem.gameObject);
		}

		pickup_point = GameObject.Find("PickUpPoint").transform;
		pickup_position = GameObject.Find("pickup_position").transform;

		//roll for if we reveal bad item
		int n = 0;
		if (Random.value <= probability) 
		{
			n = 1;
				
		} 

		GameObject spawned_item = Instantiate 
			(
				bombs_and_veggies[n],
				pickup_point.position,
				Quaternion.identity
			) as GameObject;

		spawned_item.transform.eulerAngles = new Vector3 (0,0,0);
		msManager.TriggerEvent("ItemSpawned");
	}


	public void ItemSpawned () 
	{
		//print("item created: " + Time.time);

	}

	void UserPass(GameObject item)
	{
//		Debug.Log("itemclean");
//		Destroy(item, 0.2f);
	}

    void Update () 
	{

	}

}