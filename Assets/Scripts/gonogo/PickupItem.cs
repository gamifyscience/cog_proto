using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;

public class PickupItem : MonoBehaviour
{
	//public static PickupItem Instance { get; private set; }
    public bool is_bomb;
    public bool itemGrabbed;
    public string Name;
    public int value;
    public int speed = 2;

    public float startTime;
    public ParticleSystem splat;
    public Transform end_position;
    public Rigidbody rbody;

    // Use this for initialization
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        itemGrabbed = false;
        //Listen for the event that we are moving and you missed the ball.
        msManager.StartListening("NoInteraction", NoInteraction);
        msManager.StartListening("Grab", Grab);
    }

    void onDisable()
    {
        msManager.StopListening("NoInteraction", NoInteraction);
        msManager.StopListening("Grab", Grab);
    }

    void OnTriggerEnter(Collider target)
    {
		if (target.GetComponent<Collider>().name == "SurpriseBoxPrefab")
        {
            Inattention();
            print("your claw hit the box");
        }
    }

    public void MoveItem()
    {
        Pass();
    }

    //if the item is not grabbed, it moves off screen or gets destroyed
    void NoInteraction()
    {
        if (itemGrabbed == false)
        {
           // end_position = GameObject.Find("EndPoint").transform;
            msManager.TriggerEvent("aiGrab");
            msManager.TriggerEvent("UpdateScore");
            //			iTween.MoveTo
            //			(
            //				gameObject, 
            //				iTween.Hash ("position", end_position, 
            //					"time", 1.4f, 
            //					"easetype", iTween.EaseType.linear, 
            //					"onComplete", "Inattention")
            //			);
			// msManager.TriggerEvent("Inattention");
        }
    }


    void Inattention()
    {
        //We forgot to get this one, destroy it!
		Destroy(gameObject, 0.1f);
    }

    void Pass()
    {
        msManager.TriggerEvent("UpdateScore");
        Destroy(gameObject, 0.3f);
    }

    void Explode()
    {
        msManager.TriggerEvent("ResetScore");
        splat.Play();
        Destroy(gameObject, splat.main.duration);
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
        else
        {
            Pass(); //MoveItem();
        }
			
    }



}
