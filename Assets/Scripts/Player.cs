using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;

    private Vector2 planarMove = Vector2.zero; // movement along axis perpendicular to gravity
    private Vector2 gravityDir = Vector2.down;
    private Vector2 gravityVelocity = Vector2.zero; // velocity along gravity direction
    private string directionOfGravity;
    private Animator anim;

    [SerializeField] float speed = 5f;
    [SerializeField] float gravityStrength = 9.81f;
    [SerializeField] float airResistance = 20.0f;
    [SerializeField] float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
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
            gravityVelocity = Vector2.zero;
            rb.linearVelocity = LinearVelocity();
        
        }

        // Rotate sprite to match gravity direction
        if (gravityDir.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            // Flip based on vertical planar movement
            if (planarMove.y > 0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (planarMove.y < -0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (gravityDir.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            // Flip based on vertical planar movement (reversed for left gravity)
            if (planarMove.y > 0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (planarMove.y < -0.1f)
                transform.localScale = new Vector3(1, 1, 1);
        }
        else if (gravityDir.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            // Flip based on horizontal planar movement (reversed for up gravity)
            if (rb.linearVelocity.x > 0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
            else if (rb.linearVelocity.x < -0.1f)
                transform.localScale = new Vector3(1, 1, 1);
        }
        else if (gravityDir.y < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            // Flip based on horizontal planar movement
            if (rb.linearVelocity.x > 0.1f)
                transform.localScale = new Vector3(1, 1, 1);
            else if (rb.linearVelocity.x < -0.1f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
            
        anim.SetBool("grounded", isGrounded());
    }


    // Move the player in the direction perpendicular to gravity
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
        anim.SetBool("walk", true);
    }

    public void StopMove()
    {
        planarMove = Vector2.zero;
        anim.SetBool("walk", false);
    }

    // Jump opposite to the current gravity direction. Only works when grounded.
    public void Jump()
    {
        if (!isGrounded()) return;
        gravityVelocity = -gravityDir.normalized * jumpForce;
        rb.linearVelocity = gravityVelocity + planarMove;
    }

    // Change the direction of gravity and apply immediate acceleration in that direction
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
        gravityVelocity = (gravityVelocity) + (gravityDir.normalized * gravityStrength);
    }

    private Vector2 LinearVelocity()
    {
        return planarMove;
    }

    private Vector2 GravityAcceleration()
    {
        // Apply air resistance to gravity velocity - slows down the change in direction over time
        if (directionOfGravity == "Up" || directionOfGravity == "Down")
        {
            if (gravityVelocity.x > 0)
                gravityVelocity.x = Mathf.Max(0, gravityVelocity.x - Time.deltaTime * airResistance);
            else if (gravityVelocity.x < 0)
                gravityVelocity.x = Mathf.Min(0, gravityVelocity.x + Time.deltaTime * airResistance);
        }
        else if (directionOfGravity == "Left" || directionOfGravity == "Right")
        {
            if (gravityVelocity.y > 0)
                gravityVelocity.y = Mathf.Max(0, gravityVelocity.y - Time.deltaTime * airResistance);
            else if (gravityVelocity.y < 0)
                gravityVelocity.y = Mathf.Min(0, gravityVelocity.y + Time.deltaTime * airResistance);
        }

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
}