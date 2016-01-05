using UnityEngine;

public class StopsOscar : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (Oscar.IsOscar(coll.gameObject))
        {
            Oscar.Instance.IsRunning = false;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (Oscar.IsOscar(coll.gameObject))
        {
            Oscar.Instance.IsRunning = true;
        }
    }
}
