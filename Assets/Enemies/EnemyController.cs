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
    private bool isFleeing = false; // Added to track fleeing state

    // Reference to other scripts for XP, coins, and UI
    public PlayerLeveling playerLeveling;
    public InventoryData inventory;
    public PickupUI pickupUI;

    [System.Obsolete]
    void Start()
    {
        currentHealth = settings.maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform.position;

        playerLeveling = FindObjectOfType<PlayerLeveling>();
        pickupUI = FindObjectOfType<PickupUI>();

        // Set initial behavior based on EnemySettings
        if (settings.behavior == EnemyBehavior.Passive)
        {
            Roam(); // Passive enemies start by roaming
        }
        else if (settings.behavior == EnemyBehavior.Neutral )
        {
            agent.SetDestination(homePosition); // Start by roaming around the home position
        }
        else if (settings.behavior == EnemyBehavior.Aggressive)
        {
            Roam();
        }
    }

    void Update()
    {
        if (!isChasing && !isFleeing)
        {
            if (settings.behavior == EnemyBehavior.Neutral && !isChasing)
            {
                // Roaming behavior for neutral enemies
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
            }
            else if (settings.behavior == EnemyBehavior.Passive)
            {
                // Roaming behavior for passive enemies
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
            }
            else if (settings.behavior == EnemyBehavior.Aggressive)
            {
                // Roaming behavior for passive enemies
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
            }
        }
        else
        {
            if (isChasing)
            {
                // Chasing behavior for neutral and aggressive enemies
                agent.SetDestination(player.position);
            }
            else if (isFleeing)
            {
                // Fleeing behavior for passive enemies
                agent.SetDestination(transform.position - (player.position - transform.position).normalized * settings.detectionRange);
            }

            // Check if the player is out of range
            if (Vector3.Distance(transform.position, player.position) > settings.detectionRange)
            {
                if (isChasing)
                {
                    // Stop chasing when the player is out of range and resume roaming
                    isChasing = false;
                    Roam();
                }
                else if (isFleeing)
                {
                    // Resume roaming when player is out of detection range
                    isFleeing = false;
                    Roam();
                }
            }
        }

        inrange();

    }

    void inrange()
    {
        if(settings.behavior == EnemyBehavior.Aggressive)
        {
            if (Vector3.Distance(transform.position, player.position) < settings.detectionRange)
            {
                isChasing = true;
            }
            else
            {
                isChasing=false;
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
            // Start fleeing when passive enemy takes damage
            isFleeing = true;
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            // Start chasing the player when neutral enemy takes damage
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
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, settings.detectionRange);
        Gizmos.DrawWireSphere(transform.position, settings.attackRange);
    }
}