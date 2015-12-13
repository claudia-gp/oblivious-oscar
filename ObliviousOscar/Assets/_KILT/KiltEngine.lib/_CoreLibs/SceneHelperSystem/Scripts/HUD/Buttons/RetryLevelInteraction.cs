using UnityEngine;
using System.Collections;

public class RetryLevelInteraction : ChangeSceneInteraction
{
	public override string StageToLoadOnClick
	{
		get 
		{
			return Application.loadedLevelName;
		}
		set
		{
		}
	}
}
