using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class World1Levels : MonoBehaviour {

	public GameObject LevelPanel1;
	public GameObject World2Image;
	public GameObject World3Image;
	public GameObject WorldsTitle;
	public GameObject World1Image;
	public GameObject ButtonsPanel1;
	public GameObject text1;
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
		

		World2Image.SetActive (false);
		World3Image.SetActive (false);
		WorldsTitle.SetActive (false);


		Vector2 InitialPosition = World1Image.transform.position;
		Vector2 InitialSize = World1Image.GetComponent<RectTransform> ().sizeDelta;

		Vector2 newPosition = new Vector2 (MovX, MovY);
		Vector2 newSize = new Vector3 (NewSizeX, NewSizeY);
		Vector2 newSize2 = new Vector2 (200,130);
		Vector2 newSize3 = new Vector2 (0,0);
		Vector2 newPosition2 = new Vector2 (3,0);

		float speedFactor = 1f;
		float duration = Vector3.Distance (InitialPosition, newPosition) / (speed * speedFactor);

		text1.transform.DOMove (new Vector2(TextMovX,TextMovY),duration);
		World1Image.transform.DOMove(newPosition,duration).OnComplete(()=>LevelPanel1.SetActive (true));
		World1Image.GetComponent<RectTransform> ().DOSizeDelta (newSize, duration, true).OnComplete(()=>ButtonsPanel1.transform.DOMove (newPosition2, duration));



		Button1.GetComponent<Image>().DOFade (0f, 5).From();
		Button2.GetComponent<Image>().DOFade (0f, 5).From();
		Button3.GetComponent<Image>().DOFade (0f, 5).From();
		Button4.GetComponent<Image>().DOFade (0f, 5).From();
		Button5.GetComponent<Image>().DOFade (0f, 5).From();

		
	}


}





	