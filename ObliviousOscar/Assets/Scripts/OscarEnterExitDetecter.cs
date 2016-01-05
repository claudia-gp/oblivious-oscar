using UnityEngine;

public abstract class OscarEnterExitDetecter : OscarEnterDetecter
{
    void OnCollisionExit2D(Collision2D collision)
    {
        if (IsOscar(collision.gameObject))
        {
            OnOscarExit();
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (IsOscar(collider.gameObject))
        {
            OnOscarExit();
        }
    }

    protected abstract void OnOscarExit();

}
