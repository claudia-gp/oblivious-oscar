using Kilt.Core;

public class NextScene : ChangeSceneInteraction
{
	public override string StageToLoadOnClick {
		get {
			var levelToLoad = (LevelManager.CurrentIndex + 1) % LevelManager.LevelCount;

			return SceneManager.GetLevelNameByIndex (levelToLoad);
		}
		set {
		}
	}
}
