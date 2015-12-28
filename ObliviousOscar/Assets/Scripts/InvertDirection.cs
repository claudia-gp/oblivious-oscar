using UnityEngine;

public class InvertDirection : MonoBehaviour
{
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag.Equals (Oscar.Tag)) {
			Oscar.Instance.InvertDirection ();
		}
	}
}
