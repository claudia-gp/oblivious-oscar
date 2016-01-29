using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryAnimation : MonoBehaviour
{

	public Sprite[] introSequence;
	public GameObject[] texts;
	public GameObject initialText;
	int current = 0;
	Image image;

	void Awake ()
	{
		image = GetComponent<Image> ();
	}

	public void ChangeImage ()
	{
		if (current == introSequence.Length) {
			GoToLevel ();
		} else { 
			if (current == 0) {
				initialText.SetActive (false);
			} else {
				texts [current - 1].SetActive(false);
			}

			texts [current].SetActive(true);
			image.overrideSprite = introSequence [current];

			current++;
		}
	}

	public void GoToLevel ()
	{
		LevelManager.LoadAfterLoadingScreen (LevelManager.FirstLevel);
	}

}
