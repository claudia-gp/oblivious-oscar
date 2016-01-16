using UnityEngine;
using DG.Tweening;

public class TappableSwitchElevator : MonoBehaviour
{
	public float offsetX = 0f, offsetY = 0f;
	public float speed = 1f;
	public Sprite switchOnSprite;
	public bool dontMoveTheSwitch;

	Elevator elevator;
	GameObject elevatorGO;
	Vector3 initialPosition, targetPosition;
	SpriteRenderer spriteRenderer;
	float duration;

	public bool IsClicked{ get; private set; }

	const float additionalVerticalOffset = 0.1f;
	const float speedFactor = 6f;

	void Awake ()
	{
		elevatorGO = transform.parent.gameObject;
		elevator = elevatorGO.GetComponent<Elevator> ();

		spriteRenderer = GetComponent<SpriteRenderer> ();

		initialPosition = elevatorGO.transform.position;

		targetPosition = new Vector3 (initialPosition.x + offsetX, initialPosition.y + offsetY + additionalVerticalOffset, initialPosition.z);

		duration = Vector3.Distance (initialPosition, targetPosition) / (speed * speedFactor);
	}

	public void OnClick ()
	{
		IsClicked = true;
		if (dontMoveTheSwitch) {
			transform.SetParent (elevator.transform.parent);
		}

		if (elevator.IsOscarIn) {
			Oscar.Instance.transform.SetParent (elevator.transform);
		}

		spriteRenderer.sprite = switchOnSprite;
		elevator.transform.DOMove (targetPosition, duration).OnComplete (
			() => Oscar.Instance.transform.SetParent (null)
		);
	}
}
