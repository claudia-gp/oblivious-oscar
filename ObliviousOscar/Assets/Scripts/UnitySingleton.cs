using UnityEngine;

public abstract class UnitySingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	protected UnitySingleton(){}

	public static T Instance { get; private set; }

	protected void Awake()
	{
		if (Instance == null) {
			Instance = GetComponent<T>();
		} else {
			DestroyImmediate(gameObject);
		}
	}

}
