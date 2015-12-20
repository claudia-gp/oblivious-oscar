using UnityEngine;
using System.Collections;

public class TappableDoor : MonoBehaviour
{
	

	public Sprite openDoorSprite;

	
	public void OnClick ()
	{
		GetComponent<SpriteRenderer> ().sprite = openDoorSprite;
		Destroy (GetComponent<BoxCollider2D> ());
		Oscar.Instance.IsRunning = true;
		
		//TODO to change: orrible workaroung
		Oscar.Instance.gameObject.GetComponent<Animator> ().enabled = true;
		Camera.main.transform.parent = Oscar.Instance.transform;
		
	}
}
