using UnityEngine;
using System.Collections;

public class SetCurrentTime4Digits : MonoBehaviour {

	void Update ()
	{
		string text = System.DateTime.Now.Hour.ToString("00") + ":" +System.DateTime.Now.Minute.ToString("00");

		if(System.DateTime.Now.Millisecond % 1000 > 500) text = text.Substring(0,2) + ' ' + text.Substring(3,2);

		GetComponent<Clock4Digits>().text = text;
	}
}
