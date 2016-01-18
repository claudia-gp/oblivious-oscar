using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class World2Levels : MonoBehaviour {

	public GameObject LevelPanel2;
	public GameObject World2Image,World3Image,World1Image;
	public GameObject WorldsTitle;
	public GameObject ButtonsPanel2;
	public GameObject text2;
	public GameObject Button1,Button2,Button3,Button4,Button5;
	public GameObject BackButton1,BackButton2;
	public float speed;
	public float WorldNewSizeX,WorldNewSizeY;
	public float MoveWorldImageX,MoveWorldImageY;



	public void OnClick(){

		text2.SetActive (false);
		World1Image.SetActive (false);
		World3Image.SetActive (false);
		WorldsTitle.SetActive (false);
		BackButton1.SetActive (false);
		BackButton2.SetActive (true);

		Vector2 InitialPosition = World2Image.transform.position;
		Vector2 newPosition = new Vector2 (MoveWorldImageX,MoveWorldImageY);
		Vector2 newSize = new Vector3 (WorldNewSizeX, WorldNewSizeY);

		float speedFactor = 1f;
		float duration = Vector3.Distance (InitialPosition, newPosition) / (speed * speedFactor);


		World2Image.transform.DOMove (newPosition, duration).OnComplete (() => LevelPanel2.SetActive (true));
		World2Image.GetComponent<RectTransform> ().DOSizeDelta (newSize, duration, true);

		Button1.GetComponent<Image>().DOFade (0f, 3).From();
		Button2.GetComponent<Image>().DOFade (0f, 3).From();
		Button3.GetComponent<Image>().DOFade (0f, 3).From();
		Button4.GetComponent<Image>().DOFade (0f, 3).From();
		Button5.GetComponent<Image>().DOFade (0f, 3).From();
	}


}
