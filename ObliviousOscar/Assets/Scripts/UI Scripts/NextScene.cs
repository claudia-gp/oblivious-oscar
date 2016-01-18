using Kilt.Core;

public class NextScene : ChangeSceneInteraction
{
	public override string StageToLoadOnClick {
		get {
			var levelToLoad = (LevelManager.CurrentIndex + 1) % LevelManager.LevelCount;
			LevelManager.ResetLevel ();
			return SceneManager.GetLevelNameByIndex (levelToLoad);
		}
		set {
		}
	}
}
