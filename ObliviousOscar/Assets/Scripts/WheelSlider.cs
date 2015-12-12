using UnityEngine;
using System.Collections;

public class WheelSlider : MonoBehaviour {

	public GameObject slider;
	public float speed;
		
	IEnumerator Start()
	{
		var pointA = transform.position;
		var pointB = new Vector3 (transform.position.x, slider.GetComponent<SpriteRenderer> ().bounds.extents.y, transform.position.z);
	
		while (true) {
			yield return StartCoroutine(MoveObject(transform, pointA, pointB));
			yield return StartCoroutine(MoveObject(transform, pointB, pointA));
		}
	}
		
	IEnumerator MoveObject(Transform thisTransform, Vector3 startPos, Vector3 endPos)
	{
		var i= 0.0f;
		while (i < 1.0f) {
			i += Time.deltaTime * speed;
			thisTransform.position = Vector3.Lerp(startPos, endPos, i);
			yield return null; 
		}
	}
}
