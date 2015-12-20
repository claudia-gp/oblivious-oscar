using UnityEngine;
using System.Collections;
using Kilt.Core;

public class NextScene : ChangeSceneInteraction
{
	public override string StageToLoadOnClick {
		get {
			var levelToLoad = (Application.loadedLevel + 1) % Application.levelCount;
			#if UNITY_5_0 || UNITY_5_1 || UNITY_5_2 || UNITY_4
			return SceneManager.GetLevelNameByIndex (levelToLoad);
			#else
			return SceneManager.GetLevelNameByIndex(levelToLoad);
			#endif
		}
		set {
		}
	}
}
