using UnityEngine;

public class Elevator : MonoBehaviour
{
	public bool IsOscarIn{ get; private set; }

	void OnCollisionEnter2D (Collision2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			IsOscarIn = true;
		}
	}

	void OnCollisionExit2D (Collision2D coll)
	{
		if (Oscar.IsOscar (coll.gameObject)) {
			IsOscarIn = false;
		}
	}

}
