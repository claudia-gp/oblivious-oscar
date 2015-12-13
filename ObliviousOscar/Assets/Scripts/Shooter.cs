using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public float speedFactor;
	public float delay;

	// Use this for initialization
	void Start () {
		StartCoroutine (Shoots ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Shoots()
	{
		while (true) {
			yield return new WaitForSeconds (delay);
			GameObject clone = (GameObject)Instantiate (projectile, new Vector3(transform.position.x, transform.position.y+1), Quaternion.identity);
			clone.GetComponent<Rigidbody2D>().velocity = -transform.right * speedFactor;
		}
	}
}