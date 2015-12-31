using UnityEngine;
using System.Collections;

public class ShootAPlayerInRange : MonoBehaviour {

	public bool shootLeft = true;
	public GameObject projectileRight;
	public GameObject projectileLeft;
	public float waitBetweeenProjectiles;
	private float shotCounter;
	public float projectileSpeed;
	public bool isShooting;

	void Start () {
		shotCounter = 0;
		isShooting = true;
	}
	
	void Update () {
		shotCounter -= Time.deltaTime;
		if (shotCounter < 0 && isShooting) {
			if (shootLeft) {
				GameObject clone = (GameObject)Instantiate (projectileRight, new Vector3(transform.position.x - 2, transform.position.y+0.5f), Quaternion.identity);
				clone.GetComponent<Rigidbody2D>().velocity = -transform.right*projectileSpeed;
				} else {
				GameObject clone = (GameObject)Instantiate (projectileLeft, new Vector3(transform.position.x + 2, transform.position.y+0.5f), Quaternion.identity);
				clone.GetComponent<Rigidbody2D>().velocity = transform.right*projectileSpeed;
			}

			shotCounter = waitBetweeenProjectiles;
		}
	}

}
