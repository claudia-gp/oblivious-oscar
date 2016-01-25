using UnityEngine;

public class TappableMagnet : Tappable
{
	public float initDistance;
	public bool isActivated;
	DistanceJoint2D dj;
	bool soundPlayed;

	void Start ()
	{
		dj = GetComponent<DistanceJoint2D> ();
	}

	public override void OnTap ()
	{
		if (!soundPlayed) {
			SoundManager.Instance.Play (SoundManager.Instance.MagnetActive);
			soundPlayed = true;
		}

		if (!isActivated) {
			dj.distance = 0;
			isActivated = true;
		} else {
			dj.distance = initDistance;
			isActivated = false;
		}
	}
	
}
