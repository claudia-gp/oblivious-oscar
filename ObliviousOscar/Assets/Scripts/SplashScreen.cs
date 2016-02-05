using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
	const float splashScreenDuration = 1.5f;

	void Start ()
	{
		StartCoroutine (LaunchGame ());
	}

	IEnumerator LaunchGame ()
	{
		var loading = SceneManager.LoadSceneAsync (LevelManager.MainMenu);
		loading.allowSceneActivation = false;
		yield return new WaitForSeconds (splashScreenDuration);
		loading.allowSceneActivation = true;
	}
}
