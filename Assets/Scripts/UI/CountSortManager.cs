using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountSortManager : MonoBehaviour {

	public GameObject CountHolder;
	public int myid;
	public int myvalue;
	private Text m_textLabel;

	public Button btn;  //script trigger this button

	private void Awake()
	{
		m_textLabel = GetComponent<Text>();

		if (m_textLabel == null)
		{
			Debug.LogError("Missing Text component!", gameObject);
			enabled = false;
			return;
		}

		//msManager.StartListening ("Targeted", Targeted);
		//msManager.StartListening ("BarelyTargeted", BarelyTargeted);
	}

	// Use this for initialization
	public void Start () {
		int myvalue = 0;
		m_textLabel.text = myvalue.ToString();
	}

	public void setupDecoder (){

		if (!DroneTargeting.Instance.HasTarget ())
			return;
		HiLoManager.CountOrder = 1;
		int listvalue = HiLoManager.OnSetValue(myid);

		myvalue	= listvalue;
		m_textLabel.text = myvalue.ToString();

	}

	public void testDecoder(){
		
		if (!DroneTargeting.Instance.HasTarget ())
			return;


		//repop value with next number if the order is correct
		// TODO there is a hack here that set countvalue position +1 so it can be incremented
		int myPosition = HiLoManager.CountOrder;
		var ListManager = HiLoManager.Instance;

		//Debug.LogError(HiLoManager.CountOrder + " is the CountOrder");
		int testvalue = HiLoManager.OnGetValue(myvalue, (myPosition -1));
		if (myvalue != testvalue)
		{
			HiLoManager.CountOrder = myPosition + 1;
			myvalue	= testvalue;
			m_textLabel.text = myvalue.ToString();
			HiLoManager.Instance.ProcessPlayerSelect();
		}
	}


/*	private void Targeted()
	{
		//if (DroneTargeting.Instance.HasTarget ())
			
			Button thisBtn = btn.GetComponent<Button>();
			thisBtn.onClick.Invoke ();
			print ("you pressed that button = magic");

	} */

	private void BarelyTargeted()
	{
		
	}

	private void OnListChanged(int newNumber)
	{
		if (m_textLabel != null)
		{
			print ("onlistchanged returned this " + newNumber);//newNumber)m_textLabel.text = newNumber.ToString();
		}
	}
		
}
