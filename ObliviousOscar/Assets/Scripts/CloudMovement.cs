using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour {

	public float ReduceSpeed;


	void Start () {
	
	}
	

	void Update () {
		transform.Translate(Vector3.left/ReduceSpeed);
	}
}
