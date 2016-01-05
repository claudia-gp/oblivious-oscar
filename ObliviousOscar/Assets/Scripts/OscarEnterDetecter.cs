using UnityEngine;

public abstract class OscarEnterDetecter : MonoBehaviour
{
    public const string Tag = "Oscar";

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsOscar(collision.gameObject))
        {
            OnOscarEnter();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (IsOscar(collider.gameObject))
        {
            OnOscarEnter();
        }
    }

    protected abstract void OnOscarEnter();

    static public bool IsOscar(GameObject go)
    {
        return go.CompareTag(Tag);
    }
}
