using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems;

public class PickupItem : MonoBehaviour
{

    public bool is_bomb;
    public bool itemGrabbed;
    public string Name;
    public int value;
    public int speed = 2;
    public RaycastHit hit;
    public Ray ray;
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

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<Collider>().name == "SurpriseBoxPrefab")
        {
            Inattention();
            print("your box hit the apple");
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
            end_position = GameObject.Find("EndPoint").transform;
            msManager.TriggerEvent("aiGrab");
            //			iTween.MoveTo
            //			(
            //				gameObject, 
            //				iTween.Hash ("position", end_position, 
            //					"time", 1.4f, 
            //					"easetype", iTween.EaseType.linear, 
            //					"onComplete", "Inattention")
            //			);
            Inattention();
        }
    }


    void Inattention()
    {
        //We forgot to get this one, destroy it!
        Destroy(gameObject);
    }

    void Pass()
    {
        msManager.TriggerEvent("UpdateScore");
        Destroy(gameObject, 0.3f);

    }

    void Explode()
    {
        msManager.TriggerEvent("ResetScore");
        ParticleSystem splat = GetComponent<ParticleSystem>();
        splat.Play();
        Destroy(gameObject, splat.main.duration);
    }

    public void Grab()
    {
        //we tapped it now try to collide with it

        itemGrabbed = true;

        print("you tapped " + this.name);

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

        //We are not tapping anymore
        /*
    if (Input.GetMouseButtonDown(0)) 
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast (ray, out hit))
        if (hit.collider != null) {
            //we tapped it now try to collide with it
            msManager.TriggerEvent ("Grab");
            itemGrabbed = true;
            //hit.collider.enabled = false;
            print ("you tapped " + hit.collider.name);
        }
        if ( this.is_bomb != true)
            msManager.TriggerEvent ("GrabTime");

        if(this.is_bomb)
        {
            Explode();
        } else {
            Pass (); //MoveItem();
        }
    }
    */
    }



}
