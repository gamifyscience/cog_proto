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
		SceneManager.LoadScene ("DecoderHiLo", LoadSceneMode.Single);
	}

	public void ButtonMenu() {
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}

}