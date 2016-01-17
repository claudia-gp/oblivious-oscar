using UnityEngine;
using System.Collections;

public class TriggerFallingBoxes : OscarEnterDetecter
{
    const float GravityScale = 0.2f;
    public GameObject box;
    public float gravityIndex = 4f;
    Rigidbody2D rb;

    void Awake()
    {
        rb = box.GetComponent<Rigidbody2D>();
    }

    IEnumerator RevertGravity()
    {
        yield return new WaitForSeconds(0.5f);
        rb.gravityScale = GravityScale;
    }

    protected override void OnOscarEnter()
    {
        rb.isKinematic = false;
        rb.gravityScale = gravityIndex;
        StartCoroutine(RevertGravity());
    }
}
