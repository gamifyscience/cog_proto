using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NumberGen : MonoBehaviour {
	public int outcome;
	public int lastRoot = 10;
	public int round = 1;
	public float hiRange = 20f;
	public int NumPause = 4;
	public Text HiLowText;
	public Text Score;
	public int points = 0;
	public bool targetState = false;


	// Use this for initialization
	void Start () {
		StartCoroutine ( GenHiLow () );
		Score.text = points.ToString ();
		msManager.StartListening ("TargetAcquired", TargetAcquired);
		msManager.StartListening ("TargetOff", TargetOff);
	}

	void TargetAcquired ()
	{
		if (targetState == false) {
			targetState = true;
			StartCoroutine (GenHiLow ());
		}
	}

	void TargetOff ()
	{
		targetState = false;
	}


	IEnumerator GenHiLow()
	{
		print (round);
		if (round <= 15) {
			yield return new WaitForSeconds (NumPause);
			if (targetState == false) {
				
				float x = Random.Range (2f, lastRoot) / 2;
				float n = Random.Range (x, hiRange);
				int thisRoot = Mathf.RoundToInt (n);

				outcome = 0;
				if (lastRoot <= thisRoot) {
					outcome = 1;
					if (lastRoot == thisRoot)
						thisRoot++;
				}


				lastRoot = Mathf.RoundToInt (n);
				HiLowText.text = lastRoot.ToString ();
				round++;
			}
		}
	}

	public void CompareOutcome(int compareBool)
	{
		if (outcome == compareBool) {
			points++;
			print ("on Target: " + targetState);
		}
		print (outcome + ":" + compareBool + ":" + points);
		Score.text = points.ToString ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}