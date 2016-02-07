using UnityEngine;
using System.Collections;

public class cameraSetToOscar : OscarEnterDetecter {

	protected override void OnOscarEnter()
	{
		Camera.main.transform.SetParent (Oscar.Instance.transform); 
	}
}
