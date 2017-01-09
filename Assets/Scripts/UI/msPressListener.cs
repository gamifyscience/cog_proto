using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using UnityEngine.EventSystems; 


public class msPressListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
	private string FunctionName;

	// Use this for initialization
	void OnEnable () 
	{
		//string FunctionName = "Press" + this.gameObject.name;
	}


	/// <summary>
	/// Raises the pointer click event.
	/// </summary>
	/// <param name="eventData">Event data.</param>
	public void OnPointerClick(PointerEventData eventData)
	{
		string FunctionName = "Press" + this.gameObject.name;
		Debug.LogError (FunctionName + "was clicked");

		msManager.TriggerEvent (FunctionName);
	}

	//Keeping these so the click event gets registered.
	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerUp(PointerEventData eventData)
	{
	}



//	

}
