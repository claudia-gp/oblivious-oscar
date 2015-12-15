using UnityEngine;
using System.Collections;

public class NextScene : ChangeSceneInteraction
{
	public override string StageToLoadOnClick {
		get {
			return SceneManager.GetLevelNameByIndex ((Application.loadedLevel + 1) % Application.levelCount);
		}
		set {
		}
	}
}
