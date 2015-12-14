using UnityEngine;

[ExecuteInEditMode]
public class UndergroundFiller : MonoBehaviour
{
	public bool createBlocks;
	public GameObject other;
	
	void Update ()
	{
		if (createBlocks) {
			createBlocks = false;
			GameObject obj1 = gameObject;
			GameObject obj2 = other;
			GameObject newObj;

			for (float i = obj1.transform.position.x; i < obj2.transform.position.x + 1; i++) {
				for (float j = obj1.transform.position.y; j < obj2.transform.position.y + 1; j++) {
					newObj = Instantiate (obj2, new Vector3 (i, j), Quaternion.identity) as GameObject;
					newObj.transform.SetParent (obj2.transform.parent);
				}
			}
			Destroy (newObj);
		}
	}
}
