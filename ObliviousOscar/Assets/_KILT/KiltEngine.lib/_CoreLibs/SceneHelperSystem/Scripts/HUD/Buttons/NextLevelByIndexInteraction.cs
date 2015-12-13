using UnityEngine;
using System.Collections;

public class NextLevelByIndexInteraction : ChangeSceneInteraction
{
	public override string StageToLoadOnClick
	{
		get 
		{
			return SceneManager.GetLevelNameByIndex(Application.loadedLevel + 1);
		}
		set
		{
		}
	}
}
