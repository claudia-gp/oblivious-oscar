using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryAnimation : MonoBehaviour
{

	public Sprite[] introSequence;
	public Text[] texts;
	public Text initialText;
	public Text initialText2;

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
				initialText.enabled = false;
				initialText2.enabled = false;
			} else {
				texts [current - 1].enabled = false;
			}

			texts [current].enabled = true;
			image.overrideSprite = introSequence [current];

			current++;
		}
	}

	public void GoToLevel ()
	{
		LevelManager.LoadAfterLoadingScreen (LevelManager.FirstLevel);
	}

}
