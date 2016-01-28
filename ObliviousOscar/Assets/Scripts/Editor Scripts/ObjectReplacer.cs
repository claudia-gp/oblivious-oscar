#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ObjectReplacer : MonoBehaviour
{
	public bool ReplaceObject;
	public string SpriteName = "";

	public Sprite[] NewSprites;
	public float[] Probabilities;

	void Update ()
	{
		if (ReplaceObject) {
			ReplaceObject = false;

			if (Probabilities.Length != NewSprites.Length) {
				if (Probabilities.Length != 0) {
					Debug.Log ("Wrong probabilities length");
					return;
				}
				Probabilities = new float[NewSprites.Length];
				for (int i = 0; i < NewSprites.Length; i++) {
					Probabilities[i] = 1f / NewSprites.Length;
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
					    (string.IsNullOrEmpty (SpriteName) || oldGo.GetComponent<SpriteRenderer> ().sprite.name.StartsWith (SpriteName))) {
						Sprite newSprite = chooseSprite ();
						sr.sprite = newSprite;
					}
				} catch (System.Exception ex) {
					Debug.Log ("Problem with object: " + oldGo + "\n" + ex);
				}
				
			}
		}
	}

	Sprite chooseSprite ()
	{
		Debug.Assert (NewSprites.Length == Probabilities.Length);
		int n = NewSprites.Length;

		float[] probLevel = new float[n];
		float accum = 0f;
		for (int i = 0; i < n; i++) {
			accum += Probabilities[i];
			probLevel[i] = accum;
		}

		float random = Random.value;
		for (int i = 0; i < n; i++) {
			if (probLevel[i] > random) {
				return NewSprites[i];
			}
		}

		Debug.LogError ("I shouldn't reach this code");
		return null;
	}
}

#else
public class ObjectReplacer : UnityEngine.MonoBehaviour
{
}
#endif