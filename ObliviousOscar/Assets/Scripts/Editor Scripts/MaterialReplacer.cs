#if UNITY_EDITOR

using UnityEngine;

[ExecuteInEditMode]
public class MaterialReplacer : MonoBehaviour
{
	public bool replace;

	public Material material;

	void Update ()
	{
		if (replace) {
			replace = false;

			SpriteRenderer[] all = FindObjectsOfType<SpriteRenderer> ();
			foreach (var sr in all) {
				try {
					sr.material = material;
				} catch (System.Exception ex) {
					Debug.Log ("Problem " + ex);
				}
			}

			DestroyImmediate (gameObject);
		}
	}
}

#else
public class MaterialReplacer : UnityEngine.MonoBehaviour
{
}
#endif