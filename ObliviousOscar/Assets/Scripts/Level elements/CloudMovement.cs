using UnityEngine;

public class CloudMovement : MonoBehaviour
{
	public float ReduceSpeed;

	void Update ()
	{
		transform.Translate (Vector3.left / ReduceSpeed);
	}
}
