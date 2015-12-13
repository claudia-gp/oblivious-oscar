using UnityEngine;
using System.Collections;

public class PreviousLevelByIndexInteraction : ChangeSceneInteraction {

	public override string StageToLoadOnClick
	{
		get 
		{
			return SceneManager.GetLevelNameByIndex(Application.loadedLevel - 1);
		}
		set
		{
		}
	}
}

