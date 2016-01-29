using UnityEngine;
using UnityEngine.UI;

public class LevelInfoText : MonoBehaviour
{
	void OnEnable ()
	{
		GetComponent<Text> ().text = LevelInfo.Instance.World + "." + LevelInfo.Instance.Level;
	}
}
