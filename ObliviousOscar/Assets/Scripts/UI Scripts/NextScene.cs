using UnityEngine;
using System.Collections;

public class NextScene : ChangeSceneInteraction
{
	public override string StageToLoadOnClick {
		get {
			return SceneManager.GetLevelNameByIndex (Application.loadedLevel + 1);
		}
		set {
		}
	}

//	public override void Send ()
//	{
//		base.Send ();
//	}
}
