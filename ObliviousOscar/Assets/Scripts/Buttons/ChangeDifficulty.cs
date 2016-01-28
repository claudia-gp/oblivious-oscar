using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
	public Sprite SlowArrowGrey,SlowArrowActive;
	public Sprite MediumArrowGrey,MediumArrowActive;
	public Sprite FastArrowGrey,FastArrowActive;

	public GameObject SlowButton,MediumButton,FastButton;

	public void SlowSpeed ()
	{
		
		OscarSpeed.Instance.Speed = OscarSpeed.Slow;
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowActive;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowGrey;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowGrey; 
	}

	public void MediumSpeed ()
	{
		 
		OscarSpeed.Instance.Speed = OscarSpeed.Medium;
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowGrey;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowActive;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowGrey;
	}

	public void FastSpeed ()
	{
		
		OscarSpeed.Instance.Speed = OscarSpeed.Fast;
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowGrey;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowGrey;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowActive; 
	}
}
