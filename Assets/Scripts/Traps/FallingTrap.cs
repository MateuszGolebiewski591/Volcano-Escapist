using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class FallingTrap : MonoBehaviour
{
    public float stunDuration = 1f;
    public LayerMask groundMask;
    public float spawnDelay = 0f;
    public float destroyBelowY = -10f;

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        // Ensure the trap will fall due to physics/gravity
        rb.gravityScale = 1f; // apply default gravity
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // only freeze rotation
        rb.linearVelocity = Vector2.zero; // clear any velocity from prefab

        // Spawn rotated randomly
        transform.rotation = Quaternion.Euler(180f, 0, 0);

        // Set collider to trigger so trap passes through ground but still detects player
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    IEnumerator Start()
    {
        if (spawnDelay > 0f)
        {
            // Pause physics by freezing all motion; unfreeze after delay
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(spawnDelay);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation; // resume falling
        }
    }

    void Update()
    {
        // Destroy trap if it falls below the map boundary
        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // If we hit the player, stun and destroy
        if (collision.CompareTag("Player"))
        {
            var playerComp = collision.GetComponent<Player>();
            if (playerComp != null)
            {
                playerComp.Stun(stunDuration);
            }
            Destroy(gameObject);
            return;
        }
    }
}
