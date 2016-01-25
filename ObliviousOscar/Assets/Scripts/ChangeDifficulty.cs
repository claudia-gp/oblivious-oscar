using UnityEngine;
using System.Collections;

public class ChangeDifficulty : MonoBehaviour
{
	const float speedSlow = 2f;
	const float speedMedium = 3f;
	const float speedFast = 4f;

	public void slowSpeed ()
	{
		Oscar.Instance.Speed = speedSlow;
	}

	public void mediumSpeed ()
	{
		Oscar.Instance.Speed = speedMedium;
	}

	public void fastSpeed ()
	{
		Oscar.Instance.Speed = speedFast;
	}

}
