using UnityEngine;

public class ChangeDifficulty : MonoBehaviour
{
	public void SlowSpeed ()
	{
		OscarSpeed.Instance.Speed = OscarSpeed.Slow;
	}

	public void MediumSpeed ()
	{
		OscarSpeed.Instance.Speed = OscarSpeed.Medium;
	}

	public void FastSpeed ()
	{
		OscarSpeed.Instance.Speed = OscarSpeed.Fast;
	}
}
