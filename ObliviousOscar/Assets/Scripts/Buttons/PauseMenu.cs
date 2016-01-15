using UnityEngine;

public class PauseMenu : MonoBehaviour
{
	public GameObject PausePanel;
	public GameObject Oscar;
	public GameObject ButtonPanel;
	public GameObject HeartsPanel;
	public GameObject PauseMenuImage;
	public GameObject BackgroundImage;

    public void OnClick()
    {
		PausePanel.SetActive(true);
		Oscar.SetActive (false);
		ButtonPanel.SetActive (false);
		HeartsPanel.SetActive(false);
		PauseMenuImage.SetActive(true);
		BackgroundImage.SetActive(false);
    }

}

