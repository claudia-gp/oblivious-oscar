using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Collections;

public class EndOfLevel : OscarEnterDetecter
{
	protected override void OnOscarEnter ()
	{
		Oscar.Instance.SetIdle (true);
		UI.Instance.winningAnim.SetActive (true);
		SoundManager.Instance.Play (SoundManager.Instance.Winning);
		StartCoroutine (WaitForAnimation ());
	}

	IEnumerator WaitForAnimation ()
	{
		yield return new WaitForSeconds (1f);
		UI.Instance.goOnButton.enabled = true;
		UI.Instance.goOnButton.DOFade (0f, 3f).From ();
	}
}
