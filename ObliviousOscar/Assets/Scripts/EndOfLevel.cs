using UnityEngine;

public class EndOfLevel : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D oscar)
    {
        if (oscar.tag.Equals(Oscar.Tag))
        {
            OscarController.Instance.StopOscarAndSayHi();
        }
    }
}
