using UnityEngine;
using UnityEngine.Events;
using System.Collections;


public class BoxSpawner : MonoBehaviour {

	public static BoxSpawner Instance { get; private set; }

	//Box
	public Transform spawn_point;
	public GameObject SurpriseBox;
	public static GameObject spawned_box; //why is this static again?
	private bool Gameover = false;

	//Items
	public GameObject[] active_inactive;	//list of items we can spawn
	public Transform pickup_point;			//target spawnpoint for the item
	public Transform pickup_position;		//where the box will open and show the item
	public float probability = 0.3f; 		//chance of getting an unwanted item
	private PickupItem m_spawnItem;			//object script of the current item
	private GameObject spawned_item;

	void OnEnable ()
	{
		msManager.StartListening ("SpawnBox", SpawnBox);
		//msManager.StartListening ("Grab", Grab);
		msManager.StartListening ("ItemSpawned", ItemSpawned);
		msManager.StartListening("DestroyBox", DestroyBox);
		msManager.StartListening("DestroyItem", DestroyItem);
		msManager.StartListening("LevelComplete", LevelComplete);
	}


	void onDisable ()
	{
		msManager.StopListening ("SpawnBox", SpawnBox);
		//msManager.StopListening ("Grab", Grab);
		msManager.StopListening ("ItemSpawned", ItemSpawned);
		msManager.StopListening ("DestroyBox", DestroyBox);
		msManager.StopListening ("DestroyItem", DestroyItem);
		msManager.StopListening("LevelComplete", LevelComplete);
	}

	public void SpawnBox()
	{
		if (Gameover == false)
        	SpawnBoxRoutine();
    }

	public void LevelComplete()
    {
		Gameover = true;
    }



    // Clone a new surprise box
    public void SpawnBoxRoutine () 
	{

		spawn_point = GameObject.Find("SpawnPoint").transform;

		spawned_box = Instantiate 
		(
			SurpriseBox, 
			spawn_point.position,
			Quaternion.identity
		) as GameObject;
		spawned_box.transform.eulerAngles = new Vector3 (0,0,0);
		//Debug.LogError ("Created " +spawned_box.ToString ());
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

		spawned_item = Instantiate 
			(
				active_inactive[n],
				pickup_position.transform
			) as GameObject;
		
		spawned_item.transform.position = new Vector3 (0,0,0);
	

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


	void DestroyItem(){
		DestroyObject (spawned_item);
	}

	void DestroyBox()
	{
		//TDB this would be better if we can check for the previous box before we start a new one 
		/// I wasnt sure how to check for the clone prefab that is instantiated because the static object was not present?!
		/// 
		//on update lets see if the box is here and create a new one if it's not.
		//startanother - the previous should be destroyed by now
		msManager.TriggerEvent ("SpawnBox");
	}

}