using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StoryAnimation : MonoBehaviour {

	public Sprite[] introSequence;
	int current = 0;
	Image image;

	void Awake(){
		image = GetComponent<Image> ();
	}
		

	public void ChangeImage ()
	{
		if(current == introSequence.Length){
			GoToLevel ();
		}
		image.overrideSprite = introSequence[current++];
	}

	public void GoToLevel (){
		LevelManager.LoadAfterLoadingScreen (LevelManager.FirstLevel);
	}

}
