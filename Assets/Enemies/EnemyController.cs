using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    private Transform player;
    private NavMeshAgent agent;
    private float currentHealth;
    private Vector3 homePosition; // Added to store the initial position for roaming
    private bool isChasing = false; // Added to track chasing state

    // Reference to other scripts for XP, coins, and UI
    public PlayerLeveling playerLeveling;
    public InventoryData inventory;
    public PickupUI pickupUI;

    void Start()
    {
        currentHealth = settings.maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform.position;

        // Set initial behavior based on EnemySettings
        if (settings.behavior == EnemyBehavior.Passive)
        {
            Roam();
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            Roam(); // Neutral enemies start roaming
        }
        else if (settings.behavior == EnemyBehavior.Aggressive)
        {
            Roam(); // Aggressive enemies start roaming
        }
    }

    void Update()
    {
        if (settings.behavior == EnemyBehavior.Aggressive)
        {
            // Roaming behavior for aggressive enemies
            if (!isChasing)
            {
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }

                if (Vector3.Distance(transform.position, player.position) <= settings.detectionRange)
                {
                    // If player is within detection range, start chasing
                    isChasing = true;
                }
            }
            else
            {
                // Chasing behavior for aggressive enemies
                agent.SetDestination(player.position);

                if (Vector3.Distance(transform.position, player.position) > settings.detectionRange)
                {
                    // If player leaves the detection range, stop chasing and resume roaming
                    isChasing = false;
                    Roam();
                }
            }
        }
    }

    void Roam()
    {
        Vector3 randomPoint = Random.insideUnitSphere * settings.roamingRadius;
        randomPoint += homePosition;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomPoint, out hit, settings.roamingRadius, 1);
        agent.SetDestination(hit.position);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        else if (settings.behavior == EnemyBehavior.Passive)
        {
            // Fleeing behavior when passive
            agent.SetDestination(transform.position - (player.position - transform.position).normalized * settings.detectionRange);
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            // Start chasing the player when neutral enemy takes damage
            isChasing = true;
        }
        else if (settings.behavior == EnemyBehavior.Aggressive)
        {
            // Chasing behavior when aggressive enemy takes damage
            isChasing = true;
        }
    }

    void Die()
    {
        Destroy(gameObject);
        // Handle player rewards for killing enemy
        playerLeveling.CheckForLevelUp(settings.exp);
        inventory.coins += settings.coins;
        pickupUI.DisplayPickup("XP", settings.exp);
        pickupUI.DisplayPickup("Coins", settings.coins);
    }

    void OnDrawGizmosSelected()
    {
        // Draw a wire sphere to represent the detection range
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, settings.detectionRange);
    }
}