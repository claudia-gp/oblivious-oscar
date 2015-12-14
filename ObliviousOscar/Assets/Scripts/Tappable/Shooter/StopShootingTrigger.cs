using UnityEngine;
using System.Collections;

public class StopShootingTrigger : MonoBehaviour {

	public GameObject shooter;
	public GameObject dragger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Oscar.Tag)) {
			shooter.GetComponent<ShootAPlayerInRange>().isShooting = false;
			dragger.SetActive(true);
		}
		
	}
}
