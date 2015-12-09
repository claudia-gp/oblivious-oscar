using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour
{
	
	void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width - 100, 10, 70, 30), "Scene 1")) {
			#pragma warning disable 618
			Application.LoadLevel (0);
			#pragma warning restore 618
		}
		if (GUI.Button (new Rect (Screen.width - 100, 50, 70, 30), "Scene 2")) {
			#pragma warning disable 618
			Application.LoadLevel (1);
			#pragma warning restore 618
		}
		if (GUI.Button (new Rect (Screen.width - 100, 90, 70, 30), "Scene 3")) {
			#pragma warning disable 618
			Application.LoadLevel (2);
			#pragma warning restore 618
		}
	}
}
