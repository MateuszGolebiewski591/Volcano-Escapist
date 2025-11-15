using UnityEngine;

public class FallingTrapSpawner : MonoBehaviour
{

    public GameObject trapPrefab;
    public Transform player;
    public float minSpawnRadius = 2f;
    public float maxSpawnRadius = 6f;
    public float spawnHeight = 8f;

    public float minInterval = 1f;
    public float maxInterval = 3f;
    public bool enabledSpawning = true;

    float spawnTimer;

    void Start()
    {
        ScheduleNext();
    }

    void Update()
    {
        if (!enabledSpawning || trapPrefab == null || player == null) return;

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            SpawnTrapNearPlayer();
            ScheduleNext();
        }
    }

    void ScheduleNext()
    {
        spawnTimer = Random.Range(minInterval, maxInterval);
    }

    void SpawnTrapNearPlayer()
    {
        // pick a random angle and distance in an annulus around the player
        float distance = Random.Range(minSpawnRadius, maxSpawnRadius);
        float angle = Random.Range(0f, 0f);
        Vector2 offset = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

        Vector3 spawnPos = player.position + new Vector3(offset.x, offset.y, 0f) + Vector3.up * spawnHeight;

        Instantiate(trapPrefab, spawnPos, Quaternion.identity);
    }
}
