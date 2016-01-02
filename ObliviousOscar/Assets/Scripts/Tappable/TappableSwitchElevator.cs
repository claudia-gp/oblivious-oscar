using UnityEngine;
using System.Collections;

public class TappableSwitchElevator : MonoBehaviour
{

	public GameObject elevator;
	public float offsetY;
	public float offsetX;
	public float speed;

	public enum direction
	{
		Up,
		Down,
		Left,
		Right}
	;

	public Sprite switchOnSprite;
	public direction elevatorDirection = direction.Up;

	bool switchActive = false;
	Sprite initialSprite;
	Vector3 initialPosition;
	Vector3 targetPosition;
	SpriteRenderer spriteRenderer;

	void Awake ()
	{
		spriteRenderer = GetComponent<SpriteRenderer> ();
		initialPosition = elevator.transform.position;
		initialSprite = spriteRenderer.sprite;

		switch (elevatorDirection) {
			case direction.Up:
				targetPosition = new Vector3 (initialPosition.x, initialPosition.y + offsetY, initialPosition.z);
				break;
			case direction.Down:
				targetPosition = new Vector3 (initialPosition.x, initialPosition.y - offsetY, initialPosition.z);
				break;
			case direction.Right:
				targetPosition = new Vector3 (initialPosition.x + offsetX, initialPosition.y, initialPosition.z);
				break;
			case direction.Left:
				targetPosition = new Vector3 (initialPosition.x - offsetX, initialPosition.y, initialPosition.z);
				break;
		}
	}

	public void OnClick ()
	{
		if (switchActive) {
			switchActive = false;
			spriteRenderer.sprite = initialSprite;
			StartCoroutine (MoveObject (elevator.transform, targetPosition, initialPosition));
		} else {
			switchActive = true;
			spriteRenderer.sprite = switchOnSprite;
			StartCoroutine (MoveObject (elevator.transform, initialPosition, targetPosition));
		}
	}

	IEnumerator MoveObject (Transform thisTransform, Vector3 startPos, Vector3 endPos)
	{
		var i = 0.0f;
		while (i < 1.0f) {
			i += Time.deltaTime * speed;
			thisTransform.position = Vector3.Lerp (startPos, endPos, i);
			yield return null; 
		}
	}
	
}
