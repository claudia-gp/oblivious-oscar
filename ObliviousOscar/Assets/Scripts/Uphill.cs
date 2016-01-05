using UnityEngine;

public class Uphill : MonoBehaviour
{
    float initialGravity;
    Rigidbody2D rb;

    void Start()
    {
        rb = Oscar.Instance.RigidBody2D;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (Oscar.IsOscar(coll.gameObject))
        {
            Oscar.Instance.IsUphill = true;
            initialGravity = rb.gravityScale;
            rb.gravityScale = 0f;
        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (Oscar.IsOscar(coll.gameObject))
        {
            Oscar.Instance.IsUphill = false;
            rb.gravityScale = initialGravity;
        }
    }

}
