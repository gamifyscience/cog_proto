﻿using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Fabric.Answers;

public class loadlevel : MonoBehaviour {

	public void  ButtonClickQuit () {
		Application.Quit ();
	}

	public void ButtonClickGoNoGo1 () {
		
		Answers.LogLevelStart ( "GoNoGo", new Dictionary<string, object> { {"PlayerLevel", PlayerData.currentLevel} } );
		SceneManager.LoadSceneAsync ("GoNoGoEspianage", LoadSceneMode.Single);
	}

	public void ButtonClickDecoder2 () {

		Answers.LogLevelStart ( "WorkingMemory", new Dictionary<string, object> { {"PlayerLevel", PlayerData.currentLevel} } );
		SceneManager.LoadScene ("DecodeCountSort", LoadSceneMode.Single);
	}
	public void ButtonClickMorrisMaze1 () {

		Answers.LogLevelStart ( "MorrisMaze", new Dictionary<string, object> { {"PlayerLevel", PlayerData.currentLevel} } );
		SceneManager.LoadScene ("MazeRoom1", LoadSceneMode.Single);
	}


	public void ButtonMenu() {
		
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);

	}

	/*
	public void ButtonMenuClickGyroTest() {
		SceneManager.LoadScene ("CamGyroTest", LoadSceneMode.Single);
	}



	public void ButtonClickDecoder1 () {
		SceneManager.LoadScene ("DecoderNBack", LoadSceneMode.Single);
	}

*/

}