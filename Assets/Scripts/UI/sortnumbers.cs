using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class sortnumbers : MonoBehaviour {

	//public static sortnumbers Instance { get; private set; }

	List<int> firstset = new List<int>() {25,24,23,22,21,20,19,18,17,16,15,14};
//	List<int> nextset  = new List<int>() {13,12,11,10, 9, 8, 7, 6, 5, 4, 3, 2};
	// Use this for initialization
	//make a list of numbers and spit out groups in random order
	void Start () {
		for (int i = 0; i < firstset.Count; i++) {
			int mixedset = firstset[i];
			int randomIndex = Random.Range(i, firstset.Count);
        	firstset[i] = firstset[randomIndex];
			firstset[randomIndex] = mixedset;
			print("this one is: " + firstset[i]);
    	 }
	}

	// Update is called once per frame
	void Update () {
		
	}
}
