using UnityEngine;

public abstract class PersistentSingleton<T> : UnitySingleton<T> where T : MonoBehaviour
{
	protected new void Awake ()
	{
		base.Awake ();
		Instance.gameObject.transform.SetParent (null);
		DontDestroyOnLoad (Instance.gameObject);
	}

	public virtual void Reset ()
	{
		Destroy (gameObject);
	}
}
