using UnityEngine;

[ExecuteInEditMode]
public class CameraController : MonoBehaviour
{
	public Transform background;

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
