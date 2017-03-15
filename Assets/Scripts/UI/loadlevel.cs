using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {


	public void  ButtonClickQuit () {
		Application.Quit ();
	}

	public void ButtonClickGoNoGo1 () {
		SceneManager.LoadSceneAsync ("GoNoGoEspianage", LoadSceneMode.Single);
	}

	public void ButtonClickDecoder1 () {
		SceneManager.LoadScene ("DecoderNBack", LoadSceneMode.Single);
	}
	public void ButtonClickDecoder2 () {
		SceneManager.LoadScene ("DecodeCountSort", LoadSceneMode.Single);
	}

	public void ButtonMenu() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

	public void ButtonMenuClickGyroTest() {
		SceneManager.LoadScene ("CamGyroTest", LoadSceneMode.Single);
	}
}