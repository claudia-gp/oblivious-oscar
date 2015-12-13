using UnityEngine;
using System.Collections;

public class ShootAPlayerInRange : MonoBehaviour {

	public GameObject projectile;
	public float waitBetweeenProjectiles;
	private float shotCounter;
	public float projectileSpeed;
	private bool isShooting;

	void Start () {
		shotCounter = 0;
		isShooting = true;
	}
	
	void Update () {
		shotCounter -= Time.deltaTime;
		if (shotCounter < 0 && isShooting) {
			GameObject clone = (GameObject)Instantiate (projectile, new Vector3(transform.position.x, transform.position.y+0.5f), Quaternion.identity);
			clone.GetComponent<Rigidbody2D>().velocity = -transform.right*projectileSpeed;
			shotCounter = waitBetweeenProjectiles;
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag(Oscar.Tag)) {
			gameObject.GetComponent<ShootAPlayerInRange>().isShooting = false;
		}
		
	}
}
