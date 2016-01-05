using UnityEngine;

public class Uphill : OscarEnterExitDetecter
{
    float initialGravity;
    Rigidbody2D rb;

    void Start()
    {
        rb = Oscar.Instance.RigidBody2D;
    }

    protected override void OnOscarEnter()
    {
        Oscar.Instance.IsUphill = true;
        initialGravity = rb.gravityScale;
        rb.gravityScale = 0f;
    }

    protected override void OnOscarExit()
    {
        Oscar.Instance.IsUphill = false;
        rb.gravityScale = initialGravity;
    }
}
