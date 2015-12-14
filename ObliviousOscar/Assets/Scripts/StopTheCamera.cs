using UnityEngine;
using System.Collections;

public class StopTheCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D oscar){
		if(oscar.tag.Equals(Oscar.Tag)){
			Camera.main.transform.parent = null;			
		}
	}
}
