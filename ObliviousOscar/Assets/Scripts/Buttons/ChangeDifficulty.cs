using UnityEngine;
using UnityEngine.UI;

public class ChangeDifficulty : MonoBehaviour
{
	public Sprite SlowArrowGrey,SlowArrowActive;
	public Sprite MediumArrowGrey,MediumArrowActive;
	public Sprite FastArrowGrey,FastArrowActive;

	public GameObject SlowButton,MediumButton,FastButton;

	/*void Start(){

		if (OscarSpeed.Instance.Speed == OscarSpeed.Slow) {
			slowChanges ();
		}
		if (OscarSpeed.Instance.Speed == OscarSpeed.Medium) {
			mediumChanges ();
		}
		if (OscarSpeed.Instance.Speed == OscarSpeed.Fast) {
			fastChanges ();
		}  

	}*/

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

	void slowChanges(){
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowActive;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowGrey;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowGrey; 
	}

	void mediumChanges(){
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowGrey;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowActive;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowGrey;
	}

	void fastChanges(){
		SlowButton.GetComponent<Image> ().overrideSprite = SlowArrowGrey;
		MediumButton.GetComponent<Image> ().overrideSprite = MediumArrowGrey;
		FastButton.GetComponent<Image> ().overrideSprite = FastArrowActive; 
	}
}
