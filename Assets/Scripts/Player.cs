using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Vector2 planarMove = Vector2.zero; // movement along axis perpendicular to gravity
    private Vector2 gravityDir = Vector2.down;
    private Vector2 gravityVelocity = Vector2.zero; // velocity along gravity direction
    private string directionOfGravity;

    [SerializeField] float speed = 5f;
    [SerializeField] float gravityStrength = 9.81f;
    [SerializeField] float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    void Update()
    {
        if (!isGrounded())
        {
            Vector2 g = GravityAcceleration();
            rb.linearVelocity = g + planarMove;
        }
        else
        {
            rb.linearVelocity = LinearVelocity();
        }
    }

    public void Move(Vector2 direction)
    {
        if (direction == Vector2.zero)
        {
            planarMove = Vector2.zero;
            return;
        }

        Vector2 tangent = new Vector2(-gravityDir.y, gravityDir.x).normalized; // axis perpendicular to gravity
        float scalar = Vector2.Dot(direction.normalized, tangent);
        planarMove = tangent * scalar * speed;
    }

    public void StopMove()
    {
        planarMove = Vector2.zero;
    }

    // Jump opposite to the current gravity direction. Only works when grounded.
    public void Jump()
    {
        if (!isGrounded()) return;
        gravityVelocity = -gravityDir.normalized * jumpForce;
        rb.linearVelocity = gravityVelocity + planarMove;
    }

    public void GravityMovement(string direction)
    {
        Vector2 newGravityDir = Vector2.zero;
        switch (direction)
        {
            case "Up":
                newGravityDir = Vector2.up;
                break;
            case "Down":
                newGravityDir = Vector2.down;
                break;
            case "Left":
                newGravityDir = Vector2.left;
                break;
            case "Right":
                newGravityDir = Vector2.right;
                break;
            default:
                Debug.LogWarning("Invalid gravity direction");
                break;
        }
        directionOfGravity = direction;
        gravityDir = newGravityDir;
        gravityVelocity = gravityDir.normalized * speed;
    }

    private Vector2 LinearVelocity()
    {
        return planarMove;
    }

    private Vector2 GravityAcceleration()
    {
        gravityVelocity += (gravityDir.normalized * gravityStrength * Time.deltaTime);
        return gravityVelocity;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(
            boxCollider.bounds.center,
            boxCollider.bounds.size,
            0f,
            gravityDir,
            0.1f,
            LayerMask.GetMask("Ground")
        );

        return raycastHit.collider != null;
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {


    // }

    // private void OnCollisionExit2D(Collision2D collision)
    // {

    // }
}