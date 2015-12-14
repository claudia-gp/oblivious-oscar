#if UNITY_EDITOR

using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GridRectifier : MonoBehaviour
{
	void Update ()
	{
		if (EditorApplication.isPlaying) {
			return;
		}

		foreach (var t in GetComponentsInChildren<Transform>()) {
			if (hasNotInGridParent (t) && !t.GetComponent<NotInTheGrid> ()) {
				t.position = new Vector3 (Mathf.Round (t.position.x), Mathf.Round (t.position.y));
			}
		}
	}
	
	bool hasNotInGridParent (Transform t)
	{
		if (t.parent == null) {
			return true;
		}
		if (t.parent.GetComponent<NotInTheGrid> ()) {
			return false;
		}
		return hasNotInGridParent (t.parent);
	}
}


#else

public class GridRectifier : UnityEngine.MonoBehaviour
{
}

#endif