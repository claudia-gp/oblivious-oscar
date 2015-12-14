using UnityEngine;
using System.Collections;

public class SignTrigger : MonoBehaviour {

	public GameObject shooter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D oscar){
		shooter.SetActive (true);
	}


}
