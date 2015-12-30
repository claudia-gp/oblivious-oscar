using UnityEngine;

public class ReverseDirection : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals (Oscar.Tag)) {
			OscarController.Instance.ReverseDirection ();
		}
	}
}
