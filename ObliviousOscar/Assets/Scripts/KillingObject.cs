using UnityEngine;

public class KillingObject : MonoBehaviour
{
	
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(Oscar.Tag))
        {
            OscarController.Instance.Kill();
        }
    }

}
