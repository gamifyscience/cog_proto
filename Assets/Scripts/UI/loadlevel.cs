using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Fabric.Answers;

public class loadlevel : MonoBehaviour {



	public void  ButtonClickQuit () {
		Application.Quit ();
	}

	public void ButtonClickGoNoGo1 () {
		
		Answers.LogLevelStart ( "GoNoGoEspianage", new Dictionary<string, object> { {"PlayerLevel", PlayerData.currentLevel} } );
		SceneManager.LoadSceneAsync ("GoNoGoEspianage", LoadSceneMode.Single);
	}

	public void ButtonClickDecoder1 () {
		SceneManager.LoadScene ("DecoderNBack", LoadSceneMode.Single);
	}
	public void ButtonClickDecoder2 () {

		Answers.LogLevelStart ( "DecodeCountSort", new Dictionary<string, object> { {"PlayerLevel", PlayerData.currentLevel} } );
		SceneManager.LoadScene ("DecodeCountSort", LoadSceneMode.Single);
	}

	public void ButtonMenu() {
		
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);

	}

	public void ButtonMenuClickGyroTest() {
		SceneManager.LoadScene ("CamGyroTest", LoadSceneMode.Single);
	}


}