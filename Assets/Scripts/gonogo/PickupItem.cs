using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;

public class PickupItem : MonoBehaviour
{
	//public static PickupItem Instance { get; private set; }
    public bool is_bomb;
    public string ItemName;

	private bool itemGrabbed;
   // public Rigidbody rbody;

    // Use this for initialization
    void Start()
    {
       // rbody = GetComponent<Rigidbody>();
        itemGrabbed = false;
        //Listen for the event that we are moving and you missed the ball.
		msManager.StartListening("aiGrab", aiGrab);
		msManager.StartListening("aiPass", aiPass);
		msManager.StartListening("NoInteraction", NoInteraction);
		msManager.StartListening("Grab", Grab);
    }

    void onDisable()
    {
		msManager.StopListening("aiGrab", aiGrab);
		msManager.StopListening("aiPass", aiPass);
		msManager.StopListening("NoInteraction", NoInteraction);
		msManager.StopListening("Grab", Grab);
    }

    void OnTriggerEnter(Collider target)
    {
		if (target.GetComponent<Collider>().name == "SurpriseBoxPrefab")
        {
			NoInteraction();
            print("your claw hit the box");
        }
		//put the item on the claw that grabs it first
		this.gameObject.transform.parent = target.transform;
    }

    //if the item is not grabbed, it moves off screen or gets destroyed
    void NoInteraction()
    {
		if (itemGrabbed == false) 
		{
			if (this.is_bomb != true){
				msManager.TriggerEvent ("aiGrab"); //let the ai collect and score/error
			} else {
				msManager.TriggerEvent ("aiPass"); //let the ai collect and not alter score
			}
		}

		msManager.TriggerEvent("UpdateScore");

		Destroy(gameObject, 0.4f);
    }

    void Explode()
    {
        msManager.TriggerEvent("ResetScore");
		Destroy(gameObject, 0.1f);
    }

    public void Grab()
    {
        //we tapped it now try to collide with it

        itemGrabbed = true;

        print("you grabbed " + this.name);

        if (this.is_bomb != true)
            msManager.TriggerEvent("GrabTime");

        if (this.is_bomb)
        {
            Explode();
        }
    }

	public void aiGrab()
	{
		//We forgot to get this one, destroy it!
		//print("too slow"); //add the time penalty
			msManager.TriggerEvent("GrabTime");
	}

	public void aiPass()
	{
		//do nothing
	}

}
