using UnityEngine;
using System.Collections;

public class TappableSwitchDoor : MonoBehaviour
{

	public GameObject doorToOpen;
	public Sprite openDoorSprite;
	public Sprite tappedSwitchSprite;

	public void OnClick ()
	{
		GetComponent<SpriteRenderer> ().sprite = tappedSwitchSprite;
		doorToOpen.GetComponent<SpriteRenderer> ().sprite = openDoorSprite;
		Destroy (doorToOpen.GetComponent<BoxCollider2D> ());
		Oscar.Instance.IsRunning = true;

		//TODO to change: orrible workaroung
		Oscar.Instance.gameObject.GetComponent<Animator> ().enabled = true;
		Camera.main.transform.parent = Oscar.Instance.transform;

	}
}
