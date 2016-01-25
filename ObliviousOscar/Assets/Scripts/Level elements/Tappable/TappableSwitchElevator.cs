using UnityEngine;
using DG.Tweening;

public class TappableSwitchElevator : MonoBehaviour
{
	public float offsetX = 0f, offsetY = 0f;
	public float speed = 1f;
	public Sprite switchOnSprite;
	public bool dontMoveTheSwitch;
	public bool stopOscarOnThePlatform;
	public bool linearMovement = true;

	Elevator elevator;
	GameObject elevatorGO;
	Vector3 initialPosition, targetPosition;
	SpriteRenderer spriteRenderer;
	float duration;
	bool wasClicked;

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
		if (!wasClicked) {
			wasClicked = true;
			SoundManager.Instance.Play (SoundManager.Instance.Switch);
		}

		if (dontMoveTheSwitch) {
			transform.SetParent (elevator.transform.parent);
		}

		if (elevator.IsOscarIn) {
			Oscar.Instance.transform.SetParent (elevator.transform);
			if (stopOscarOnThePlatform) {
				Oscar.Instance.SetIdle (true);
			}
		}

		spriteRenderer.sprite = switchOnSprite;

		elevator.transform.DOMove (targetPosition, duration).
		SetEase (linearMovement ? Ease.Linear : Ease.OutQuad).
		OnComplete (() => Oscar.Instance.transform.SetParent (null));
	}
}
