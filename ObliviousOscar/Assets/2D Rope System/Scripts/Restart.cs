using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{

	//when mouse is clicked on this object reload current scene
	void OnMouseDown ()
	{
		#pragma warning disable 618
		Application.LoadLevel (Application.loadedLevel);
		#pragma warning restore 618
	}
	
	// Update is called once per frame
	void Update ()
	{
		//if touchcount is more than 2 reload current scene
		if (Input.touchCount > 2) {
			#pragma warning disable 618
			Application.LoadLevel (Application.loadedLevel);
			#pragma warning restore 618
		}
	}
}
