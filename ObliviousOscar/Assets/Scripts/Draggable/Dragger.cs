using UnityEngine;
using System.Collections;
using System.Collections.Generic;


//If this class is active, all objects in scene can be dragged by mouse click
public class Dragger : GlobalPressBehaviour
{
	#region Singleton
	
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
	
	#endregion
	
	#region Unity Functions
	
	protected virtual void OnLevelLoaded ()
	{
		if (Dragger.Instance != null && Dragger.Instance != this)
			KiltUtils.Destroy (Dragger.Instance.gameObject);
		Dragger.Instance = this;
	}
	
	protected virtual void Update ()
	{
		Move ();
	}
	
	#endregion
	
	#region Helper Functions
	
	protected virtual void Move ()
	{
		if (Pressed && ObjectPressed != null && ObjectPressed.tag == Draggable.Tag) {
			Draggable d = ObjectPressed.GetComponent<Draggable> ();

			Vector3 v_oldPos = ObjectPressed.transform.position;
			Vector2 v_worldMousePosition = GetWorldMousePosition (ObjectPressed);
			if (!d.fixedX) {
				v_oldPos.x = v_worldMousePosition.x + DeltaClick.x;
			}
			if (!d.fixedY) {
				v_oldPos.y = v_worldMousePosition.y + DeltaClick.y;
			}

			ObjectPressed.transform.position = v_oldPos;
		}
	}
	
	#endregion
}
