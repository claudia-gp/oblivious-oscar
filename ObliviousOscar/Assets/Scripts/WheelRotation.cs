using UnityEngine;
using System.Collections;

public class WheelRotation : MonoBehaviour {

	public float rotationSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,50*Time.deltaTime*rotationSpeed); //rotates 50 degrees per second around z axis
	}
}
