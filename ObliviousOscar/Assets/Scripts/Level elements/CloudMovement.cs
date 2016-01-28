using UnityEngine;

public class CloudMovement : MonoBehaviour
{
	const float speedConstant = 1000f;

	public float Speed = 10f;

	void Update ()
	{
		transform.Translate (Speed / speedConstant * Vector3.left);
	}
}
