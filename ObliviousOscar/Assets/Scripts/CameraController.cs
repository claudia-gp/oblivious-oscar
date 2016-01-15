using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
	const float AspectRatioConstant = 9f;

	Camera cam;

	void Awake ()
	{
		cam = GetComponent<Camera> ();
	}

	void OnRenderObject ()
	{
		cam.orthographicSize = AspectRatioConstant / cam.aspect;
	}
}
