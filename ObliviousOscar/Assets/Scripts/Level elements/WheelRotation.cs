using UnityEngine;

public class WheelRotation : MonoBehaviour
{
	public float rotationSpeed;

	void Update ()
	{
		transform.Rotate (0, 0, 50 * Time.deltaTime * rotationSpeed); //rotates 50 degrees per second around z axis
	}
}
