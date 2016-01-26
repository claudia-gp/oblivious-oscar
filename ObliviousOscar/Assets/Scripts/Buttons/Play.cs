using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Play : MonoBehaviour
{

	public void LoadStage ()
	{
		
		SceneManager.LoadSceneAsync (LevelManager.FirstLevel).allowSceneActivation = true;

		var loadingScreen = MainMenuCanvas.Instance.LoadingScreen;
		loadingScreen.SetActive (true);
		StartCoroutine (LoadingText ());
	}

	IEnumerator LoadingText ()
	{
		var loadingText = MainMenuCanvas.Instance.LoadingScreen.GetComponentInChildren<Text> ();

		while (true) {
			yield return new WaitForSeconds (0.2f);
			loadingText.text = loadingText.text + ".";
		}
	}

}
