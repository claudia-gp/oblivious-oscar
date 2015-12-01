using UnityEngine;
using System.Collections;
using TouchScript.Gestures;


public abstract class Tappable : MonoBehaviour
{

	abstract public void OnTap ();


	public void Start ()
	{
		TapGesture tapGesture = gameObject.AddComponent<TapGesture> ();
		tapGesture.UseSendMessage = true;
	}

}
