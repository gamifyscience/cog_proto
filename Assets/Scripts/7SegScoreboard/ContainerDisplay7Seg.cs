using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class ContainerDisplay7Seg : MonoBehaviour {

	public string text = "";
	public Color onColor = Color.red;
	public Color offColor = Color.black;

	private List<GameObject> displayArray = new List<GameObject>();

	void Start ()
	{

		for(int index = 0; index < transform.childCount; ++index)
		{			
			if(transform.GetChild(index).gameObject.name == "Display7Seg") displayArray.Add(transform.GetChild(index).gameObject);			
		}
	}

	void Update()
	{
		UpdateDisplays ();
	}

	void UpdateDisplays ()
	{
		int pointCounter = 0;

		for(int index = 0; index < text.Length; ++index)
		{
			if(index - pointCounter < displayArray.Count)
			{
				var d7seg = displayArray[index-pointCounter].GetComponent<Display7Seg>();
				d7seg.onColor = onColor;
				d7seg.offColor = offColor;

				char ch = text [index];
				bool pointState = false;

				if(index+1 < text.Length)
				{
					if(text[index+1] == '.')
					{
						pointState = true;
						++pointCounter;
						++index;
					}
					else pointState = false;
				}
				else pointState = false;

				d7seg.setChar(ch, pointState);
			}
		}


	}
}
