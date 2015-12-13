using UnityEngine;
using System.Collections;

public class URLInteraction : InteractionBehaviour 
{
	public string url = "http://google.com.br";

	public override void Send ()
	{
		if (string.IsNullOrEmpty(url)) 
			return;

		Application.OpenURL(url);
	}
}
