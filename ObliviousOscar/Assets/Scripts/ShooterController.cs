using UnityEngine;
using System.Collections;

public class ShooterController : MonoBehaviour{

	void Start () {

	}
	
	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Oscar.Tag)) {
			gameObject.GetComponent<ShootAPlayerInRange>().isShooting = false;
		}

	}

}
