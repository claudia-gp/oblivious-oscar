using UnityEngine;
using System.Collections;

public class TappableMagnetTimed : Tappable {

	public float initDistance;
	public float delay = 0.5f;
	bool isActivated = false;
	DistanceJoint2D dj;

	void Awake (){
		dj = GetComponent<DistanceJoint2D> ();
	}

	public override void OnClick ()	{
		if (isActivated == false) {
			dj.distance = 0;
			isActivated = true;
			StartCoroutine (waitAndFall ());
		} 

	}

	IEnumerator waitAndFall() {
		yield return new WaitForSeconds (delay);
		dj.distance = initDistance;
		isActivated = false;
	}
}
