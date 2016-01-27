using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class WorldLevels : MonoBehaviour
{

	public GameObject LevelPanel1, LevelPanel2;
	public GameObject World2Image, World3Image, World1Image;
	public Text WorldsTitle;
	public GameObject ButtonsPanel1, ButtonsPanel2;
	public GameObject text1, text2;
	public GameObject[] Buttons1array, Buttons2array;
	public GameObject BackButton1, BackButton2;
	public float speed1, speed2;
	public float WorldNewSizeX, WorldNewSizeY;
	public float MoveWorldImageX, MoveWorldImageY;


	public void GoIntoWorld1 ()
	{
		CommonChanges ();
		ButtonsAppearance (Buttons1array);

		text1.SetActive (false);
		World2Image.SetActive (false);

		Vector2 InitialPosition = World1Image.transform.position;
		Vector2 newPosition = new Vector2 (MoveWorldImageX, MoveWorldImageY);
		Vector2 newSize = new Vector3 (WorldNewSizeX, WorldNewSizeY);
		float speedFactor = 1f;
		float duration = Vector3.Distance (InitialPosition, newPosition) / (speed1 * speedFactor);

		World1Image.transform.DOMove (newPosition, duration).OnComplete (() => LevelPanel1.SetActive (true));
		World1Image.GetComponent<RectTransform> ().DOSizeDelta (newSize, duration, true);
		WorldsTitle.text = "World 1";
	}

	public void GoIntoWorld2 ()
	{
		CommonChanges ();
		ButtonsAppearance (Buttons2array);

		text2.SetActive (false);
		World1Image.SetActive (false);

		Vector2 InitialPosition = World2Image.transform.position;
		Vector2 newPosition = new Vector2 (MoveWorldImageX, MoveWorldImageY);
		Vector2 newSize = new Vector3 (WorldNewSizeX, WorldNewSizeY);
		float speedFactor = 1f;
		float duration = Vector3.Distance (InitialPosition, newPosition) / (speed2 * speedFactor);

		World2Image.transform.DOMove (newPosition, duration).OnComplete (() => LevelPanel2.SetActive (true));
		World2Image.GetComponent<RectTransform> ().DOSizeDelta (newSize, duration, true);
		WorldsTitle.text = "World 2";
	}


	public void CommonChanges ()
	{
		BackButton1.SetActive (false);
		BackButton2.SetActive (true);
		World3Image.SetActive (false);
	}

	public void ButtonsAppearance (GameObject[]buttons)
	{
		foreach (var i in buttons) {
			i.GetComponent<Image> ().DOFade (0f, 3).From ();
		}
	}
}