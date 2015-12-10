using UnityEngine;
using System.Collections;

public class TappableSwitch : Tappable
{

	public GameObject doorToOpen;

	public Sprite openDoorSprite;

	public Sprite tappedSwitchSprite;

	public override void OnTap ()
	{
		GetComponent<SpriteRenderer> ().sprite = tappedSwitchSprite;
		doorToOpen.GetComponent<SpriteRenderer> ().sprite = openDoorSprite;
		Destroy (doorToOpen.GetComponent<BoxCollider2D> ());
	}
}
