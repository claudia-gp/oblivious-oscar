using UnityEngine;
using System.Collections;

public class Oscar : MonoBehaviour
{
	public const string TAG = "Oscar";
	
	private const float SPEED = 3f;
	
	void Update ()
	{
		transform.position += transform.right * Time.deltaTime * SPEED;
	}
}
