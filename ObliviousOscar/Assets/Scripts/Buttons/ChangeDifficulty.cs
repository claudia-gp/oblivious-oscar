using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
	public Sprite SlowArrowGrey, SlowArrowActive;
	public Sprite MediumArrowGrey, MediumArrowActive;
	public Sprite FastArrowGrey, FastArrowActive;

	public GameObject SlowButton, MediumButton, FastButton;

	Image SlowArrow, MediumArrow, FastArrow;

	void Start ()
	{
		SlowArrow = SlowButton.GetComponent<Image> ();
		MediumArrow = MediumButton.GetComponent<Image> ();
		FastArrow = FastButton.GetComponent<Image> ();

		if (OscarSpeed.Instance.Speed == OscarSpeed.Slow) {
			slowChanges ();
		} else if (OscarSpeed.Instance.Speed == OscarSpeed.Medium) {
			mediumChanges ();
		} else if (OscarSpeed.Instance.Speed == OscarSpeed.Fast) {
			fastChanges ();
		}  
	}

	public void SlowSpeed ()
	{
		OscarSpeed.Instance.Speed = OscarSpeed.Slow;
		slowChanges ();
	}

	public void MediumSpeed ()
	{
		 
		OscarSpeed.Instance.Speed = OscarSpeed.Medium;
		mediumChanges ();
	}

	public void FastSpeed ()
	{
		
		OscarSpeed.Instance.Speed = OscarSpeed.Fast;
		fastChanges ();
	}

	void slowChanges ()
	{
		SlowArrow.overrideSprite = SlowArrowActive;
		MediumArrow.overrideSprite = MediumArrowGrey;
		FastArrow.overrideSprite = FastArrowGrey; 
	}

	void mediumChanges ()
	{
		SlowArrow.overrideSprite = SlowArrowGrey;
		MediumArrow.overrideSprite = MediumArrowActive;
		FastArrow.overrideSprite = FastArrowGrey;
	}

	void fastChanges ()
	{
		SlowArrow.overrideSprite = SlowArrowGrey;
		MediumArrow.overrideSprite = MediumArrowGrey;
		FastArrow.overrideSprite = FastArrowActive; 
	}
}
