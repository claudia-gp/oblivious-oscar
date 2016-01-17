using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ObjectReplacer : MonoBehaviour
{
	public bool ReplaceObject;
	public string OldObjectName = "grassCenter ";
	public string SpriteName = "";

	public GameObject[] NewObjects;
	public float[] Probabilities;

	void Update ()
	{
		if (ReplaceObject) {
			ReplaceObject = false;

			if (Probabilities.Length != NewObjects.Length) {
				if (Probabilities.Length != 0) {
					Debug.Log ("Wrong probabilities length");
					return;
				}
				Probabilities = new float[NewObjects.Length];
				for (int i = 0; i < NewObjects.Length; i++) {
					Probabilities[i] = 1f / NewObjects.Length;
				}
			}
			float accum = 0f;
			foreach (var p in Probabilities) {
				accum += p;
			}

			if (System.Math.Abs (accum - 1f) > 0.01) {
				Debug.Log ("Wrong probabilities sum");
				return;
			}

			SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer> ();

			foreach (var sr in spriteRenderers) {
				GameObject oldGo = sr.gameObject;
				try {
					if (sr != null &&
					    oldGo != null &&
					    (string.IsNullOrEmpty (OldObjectName) || oldGo.name.StartsWith (OldObjectName)) &&
					    (string.IsNullOrEmpty (SpriteName) || oldGo.GetComponent<SpriteRenderer> ().sprite.name.StartsWith (SpriteName))) {
						GameObject prefab = choosePrefab ();
						GameObject newGo = PrefabUtility.InstantiatePrefab (prefab) as GameObject;
						newGo.transform.position = oldGo.transform.position;
						newGo.transform.parent = oldGo.transform.parent;
						DestroyImmediate (oldGo);
					}
				} catch (System.Exception ex) {
					Debug.Log("Problem with object: " + oldGo + "\n" + ex);
				}
				
			}
		}
	}

	GameObject choosePrefab ()
	{
		Debug.Assert (NewObjects.Length == Probabilities.Length);
		int n = NewObjects.Length;

		float[] probLevel = new float[n];
		float accum = 0f;
		for (int i = 0; i < n; i++) {
			accum += Probabilities[i];
			probLevel[i] = accum;
		}

		float random = Random.value;
		for (int i = 0; i < n; i++) {
			if (probLevel[i] > random) {
				return NewObjects[i];
			}
		}

		Debug.LogError ("I shouldn't reach this code");
		return null;
	}
}
