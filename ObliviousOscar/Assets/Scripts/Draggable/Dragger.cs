using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//If this class is active, all objects with tag "Draggable" in scene can be dragged by mouse click
public class Dragger : GlobalPressBehaviour
{
	private static Dragger m_instance = null;
	
	public static Dragger Instance {
		get {
			if (m_instance == null) {
				m_instance = GameObject.FindObjectOfType (typeof(Dragger)) as Dragger;
			}
			
			return m_instance;
		}
		protected set {
			m_instance = value;
		}
	}

	protected virtual void OnLevelLoaded ()
	{
		if (Dragger.Instance != null && Dragger.Instance != this) {
			KiltUtils.Destroy (Dragger.Instance.gameObject);
		}
		Dragger.Instance = this;
	}
	
	void Update ()
	{
		if (Pressed && ObjectPressed != null && ObjectPressed.tag == Draggable.Tag) {
			Draggable d = ObjectPressed.GetComponent<Draggable> ();
			
			Vector3 newPosition = ObjectPressed.transform.position;
			Vector2 v_worldMousePosition = GetWorldMousePosition (ObjectPressed);
			if (!d.fixedX) {
				newPosition.x = v_worldMousePosition.x + DeltaClick.x;
			}
			if (!d.fixedY) {
				newPosition.y = v_worldMousePosition.y + DeltaClick.y;
			}
			
			if (d.limitX != float.PositiveInfinity) {
				if (newPosition.x > d.initialPosition.x + d.limitX) {
					newPosition.x = d.initialPosition.x + d.limitX;
				}
				if (newPosition.x < d.initialPosition.x - d.limitX) {
					newPosition.x = d.initialPosition.x - d.limitX;
				}
			}
			
			if (d.limitY != float.PositiveInfinity) {
				if (newPosition.y > d.initialPosition.y + d.limitY) {
					newPosition.y = d.initialPosition.y + d.limitY;
				}
				if (newPosition.y < d.initialPosition.y - d.limitY) {
					newPosition.y = d.initialPosition.y - d.limitY;
				}
			}

			d.Rigidbody2D.MovePosition (newPosition);
		}
	}
}
