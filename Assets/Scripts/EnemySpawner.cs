using UnityEngine;
using UnityEngine.AI;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class EnemySpawnInfo
    {
        public GameObject enemyPrefab;
        public int spawnNumber;
    }

    public EnemySpawnInfo[] enemyTypes;

    private Bounds navMeshBounds;

    void Start()
    {
        // Calculate NavMesh bounds
        navMeshBounds = CalculateNavMeshBounds();

        // Spawn initial enemies
        SpawnInitialEnemies();
    }

    void SpawnInitialEnemies()
    {
        foreach (EnemySpawnInfo enemyInfo in enemyTypes)
        {
            for (int i = 0; i < enemyInfo.spawnNumber; i++)
            {
                SpawnEnemy(enemyInfo.enemyPrefab);
            }
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab)
    {
        Vector3 spawnPosition = GetRandomNavMeshPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomNavMeshPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        NavMeshHit hit;

        int maxAttempts = 10; // Set a maximum number of attempts
        int attempts = 0;

        // Generate random points until a valid position on the NavMesh is found
        while (attempts < maxAttempts)
        {
            Vector3 randomPoint = new Vector3(Random.Range(navMeshBounds.min.x, navMeshBounds.max.x), 0f, Random.Range(navMeshBounds.min.z, navMeshBounds.max.z));
            if (NavMesh.SamplePosition(randomPoint, out hit, 1f, NavMesh.AllAreas))
            {
                randomPosition = hit.position;
                break;
            }
            attempts++;
        }

        return randomPosition;
    }

    Bounds CalculateNavMeshBounds()
    {
        NavMeshTriangulation navMeshData = NavMesh.CalculateTriangulation();

        Vector3 minBounds = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        Vector3 maxBounds = new Vector3(float.MinValue, float.MinValue, float.MinValue);

        foreach (Vector3 vertex in navMeshData.vertices)
        {
            minBounds = Vector3.Min(minBounds, vertex);
            maxBounds = Vector3.Max(maxBounds, vertex);
        }

        return new Bounds((maxBounds + minBounds) * 0.5f, maxBounds - minBounds);
    }

    public void EnemyDied(GameObject enemyPrefab)
    {
        // Respawn an enemy of the same type
        SpawnEnemy(enemyPrefab);
    }
}