using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir = Vector2.down;
    [SerializeField] float speed = 5f;

    void Awake() => rb = GetComponent<Rigidbody2D>();


    public void Up()
    {
        moveDir = Vector2.up;
    }

    public void Down()
    {
        moveDir = Vector2.down;
    }

    public void Left()
    {
        moveDir = Vector2.left;
    }

    public void Right()
    {
        moveDir = Vector2.right;
    }

    void Update()
    {
        rb.linearVelocity = moveDir * speed;
    }
}