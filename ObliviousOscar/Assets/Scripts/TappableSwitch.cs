using UnityEngine;
using System.Collections;

public class TappableSwitch : MonoBehaviour
{

	public GameObject doorToOpen;

	public Sprite openDoorSprite;

	public Sprite tappedSwitchSprite;

	public void OnClick ()
	{
		GetComponent<SpriteRenderer> ().sprite = tappedSwitchSprite;
		doorToOpen.GetComponent<SpriteRenderer> ().sprite = openDoorSprite;
		Destroy (doorToOpen.GetComponent<BoxCollider2D> ());
	}
}
