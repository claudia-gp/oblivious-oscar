using UnityEngine;
using System.Collections;

public class Oscar : MonoBehaviour
{

	private const float SPEED = 3f;
	
	void Update ()
	{
		transform.position += transform.right * Time.deltaTime * SPEED;
	}
}
