using UnityEngine;

public class OscarState
{
	public Vector3 Position{ get; private set; }

	public Vector3 Direction{ get; private set; }

	public Vector3 CameraPosition{ get; private set; }

	public OscarState (Vector3 position, Vector3 direction, Vector3 cameraPosition) {
		this.Position = position;
		this.Direction = direction;
		this.CameraPosition = cameraPosition;
	}
	
}
