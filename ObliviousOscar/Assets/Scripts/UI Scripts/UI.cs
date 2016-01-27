using UnityEngine;
using UnityEngine.UI;

public class UI : PersistentSingleton<UI>
{
	public RectTransform heartsPanel;
	public GameObject winningAnim;
	public Image goOnButton;
	public Image LevelInfo;
	public Text InfoLine1;
	public Text InfoLine2;
}
