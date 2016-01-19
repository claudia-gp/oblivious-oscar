#if UNITY_EDITOR

using UnityEngine;

[ExecuteInEditMode]
public class SpriteReplacer : MonoBehaviour
{
	public bool replace;

	public string leftName = "grassHalfLeft", midName = "grassHalfMid", rightName = "grassHalfRight";
	public Sprite leftSprite, midSprite, rigthSprite;


	void Update ()
	{
		if (replace) {
			replace = false;

			SpriteRenderer[] all = FindObjectsOfType<SpriteRenderer> ();
			foreach (var sr in all) {
				try {
					string name = sr.sprite.name;
					if (name == leftName) {
						sr.sprite = leftSprite;
					} else if (name == midName) {
						sr.sprite = midSprite;
					} else if (name == rightName) {
						sr.sprite = rigthSprite;
					}
				} catch (System.Exception ex) {
					Debug.Log ("Problem " + ex);
				}
			}

			DestroyImmediate (gameObject);
		}
	}
}

#else
public class SpriteReplacer : UnityEngine.MonoBehaviour
{
}
#endif