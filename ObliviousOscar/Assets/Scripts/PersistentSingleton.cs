using UnityEngine;

public class PersistentSingleton<T> : UnitySingleton<T> where T : MonoBehaviour
{
	protected new void Awake ()
	{
		base.Awake ();
		Instance.gameObject.transform.SetParent (null);
		DontDestroyOnLoad (Instance.gameObject);
	}
}
