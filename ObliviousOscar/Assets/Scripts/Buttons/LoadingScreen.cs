using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
	Text loadingText;
	const string baseText = "Loading";
	const int maxDots = 4;

	void Awake ()
	{
		loadingText = GetComponentInChildren<Text> ();
		loadingText.text = baseText;
		StartCoroutine (LoadingText ());
	}

	IEnumerator LoadingText ()
	{
		while (true) {
			loadingText.text = baseText;
			for (int i = 0; i < maxDots; i++) {
				yield return new WaitForSeconds (0.2f);
				loadingText.text = loadingText.text + ".";
			}
		}
	}
}
