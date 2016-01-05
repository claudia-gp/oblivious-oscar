using UnityEngine;

public class Oscar : UnitySingleton<Oscar>
{
    const float Speed = 3f;
    const float UphillSpeed = 2f;

    public Sprite finalSprite;

    public bool IsRunning{ get; set; }

    public bool IsUphill{ get; set; }

    public bool IsAnimationEnabled
    {
        get { return animator.enabled; }
        set { animator.enabled = value; }
    }

    public Sprite Sprite
    {
        get { return spriteRenderer.sprite; }
        set { spriteRenderer.sprite = value; }
    }

    public OscarState State
    {
        get{ return new OscarState(position: transform.position, direction: Direction, cameraPosition: Camera.main.transform.position); }
        set
        {
            Direction = value.Direction;
            if (Direction != transform.right)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
            transform.position = value.Position;
            Camera.main.transform.position = value.CameraPosition;
        }
    }

    public Sprite InitialSprite{ get; private set; }

    public Rigidbody2D RigidBody2D{ get; private set; }

    public Vector3 Direction{ get; private set; }

    Animator animator;
    SpriteRenderer spriteRenderer;

    protected new void Awake()
    {
        base.Awake();
	
        IsRunning = true;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        RigidBody2D = GetComponent<Rigidbody2D>();
        InitialSprite = Sprite;

        if (SavePointsManager.HasLatestState)
        {
            State = SavePointsManager.LatestState;
        }
        else
        {
            Direction = transform.right;

            SavePointsManager.InitialState = State;
            SavePointsManager.LatestState = State;
        }
    }

    void Update()
    {
        if (IsRunning)
        {
            transform.position += Direction * Time.deltaTime * Speed;
            if (IsUphill)
            {
                transform.position += transform.up * Time.deltaTime * UphillSpeed;
            }
        }
    }

    public void UpdateLatestState()
    {
        SavePointsManager.LatestState = State;
    }

    public void ResetToInitialState()
    {
        SavePointsManager.LatestState = SavePointsManager.InitialState;
    }

    public void FlipDirection()
    {
        Direction *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
