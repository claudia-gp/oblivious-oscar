using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : OscarEnterExitDetecter
{
    public new const string Tag = "Draggable";

    public bool fixedX;
    public bool fixedY;

    public float limitX = float.PositiveInfinity;
    public float limitY = float.PositiveInfinity;

    public Vector3 initialPosition;

    public Rigidbody2D Rigidbody2D{ get; private set; }

    float initialGravity = 1f;

    void Awake()
    {
        initialPosition = transform.position;
        tag = Tag;
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Rigidbody2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    protected override void OnOscarEnter()
    {
        initialGravity = Oscar.Instance.RigidBody2D.gravityScale;
        Oscar.Instance.RigidBody2D.gravityScale = 0f;
    }

    protected override void OnOscarExit()
    {
        Oscar.Instance.RigidBody2D.gravityScale = initialGravity;
        Oscar.Instance.RigidBody2D.velocity = new Vector2(0f, 0f);
    }
}
