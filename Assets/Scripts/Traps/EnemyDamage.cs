using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] private float stunDuration = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.Stun(stunDuration);
        }
    }
}
