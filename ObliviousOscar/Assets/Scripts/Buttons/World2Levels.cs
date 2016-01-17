using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class World2Levels : MonoBehaviour {

	public GameObject LevelPanel2;
	public GameObject World2Image;
	public GameObject World3Image;
	public GameObject WorldsTitle;
	public GameObject World1Image;
	public GameObject ButtonsPanel2;
	public GameObject text2;
	public GameObject Button1;
	public GameObject Button2;
	public GameObject Button3;
	public GameObject Button4;
	public GameObject Button5;
	public float speed;
	public float NewSizeX;
	public float NewSizeY;
	public float MovX;
	public float MovY;
	public float TextMovX;
	public float TextMovY;



	public void OnClick(){


		World1Image.SetActive (false);
		World3Image.SetActive (false);
		WorldsTitle.SetActive (false);



		Vector2 InitialPosition = World2Image.transform.position;
		Vector2 InitialSize = World2Image.GetComponent<RectTransform> ().sizeDelta;

		Vector2 newPosition = new Vector2 (MovX, MovY);
		Vector2 newSize = new Vector3 (NewSizeX, NewSizeY);
		Vector2 newSize2 = new Vector2 (200,130);
		Vector2 newSize3 = new Vector2 (0,0);
		Vector2 newPosition2 = new Vector2 (3,0);

		float speedFactor = 1f;
		float duration = Vector3.Distance (InitialPosition, newPosition) / (speed * speedFactor);

		text2.transform.DOMove (new Vector2(TextMovX,TextMovY),duration);
		World2Image.transform.DOMove (newPosition, duration).OnComplete (() => LevelPanel2.SetActive (true));
		World2Image.GetComponent<RectTransform> ().DOSizeDelta (newSize, duration, true).OnComplete(()=>ButtonsPanel2.transform.DOMove (newPosition2, duration));

		Button1.GetComponent<Image>().DOFade (0f, 5).From();
		Button2.GetComponent<Image>().DOFade (0f, 5).From();
		Button3.GetComponent<Image>().DOFade (0f, 5).From();
		Button4.GetComponent<Image>().DOFade (0f, 5).From();
		Button5.GetComponent<Image>().DOFade (0f, 5).From();
	}


}
