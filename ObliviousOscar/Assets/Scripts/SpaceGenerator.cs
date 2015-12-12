using UnityEngine;
using System.Collections;

public class SpaceGenerator : MonoBehaviour
{
	public GameObject groundPrefab;

	public static int multiplier = 1;

	public int amount = 1;

	void Awake ()
	{
		int numOfGeneratedBlocks = amount * multiplier;
		
		DestroyImmediate (GetComponent<SpriteRenderer> ());

		foreach (var t in transform.parent.GetComponentsInChildren<Transform>()) {
			if (t.position.x > transform.position.x) {
				t.position += new Vector3 (1.0f * numOfGeneratedBlocks, 0.0f);
			}
		}


		for (int i = 0; i < numOfGeneratedBlocks; i++) {
			Instantiate (groundPrefab, new Vector3 (transform.position.x + 1 + i, transform.parent.position.y), Quaternion.identity);
		}
	}
}
