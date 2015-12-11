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
			t.position = new Vector3 (Mathf.Round (t.position.x), Mathf.Round (t.position.y));
		}
	}
}

#else

public class GridRectifier : UnityEngine.MonoBehaviour
{
}

#endif