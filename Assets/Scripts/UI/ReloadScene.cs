using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ReloadScene : MonoBehaviour {

	
	public void onReloadScene ()
	{
		Scene scene = SceneManager.GetActiveScene();
		SceneManager.LoadScene(scene.name);
	}
}
