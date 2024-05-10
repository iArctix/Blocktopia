using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    private Transform player;
    private NavMeshAgent agent;
    private float currentHealth;
    public PlayerLeveling playerLeveling;
    public InventoryData inventory;
    private PickupUI pickupUI;

    void Start()
    {
        currentHealth = settings.maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pickupUI = GameObject.Find("PickupUi").GetComponent<PickupUI>();

        // Set initial behavior
        SetBehavior(settings.behavior);
    }

    void Update()
    {
        // If the player is within detection range, update behavior accordingly
        if (Vector3.Distance(transform.position, player.position) <= settings.detectionRange)
        {
            // Example: If the enemy is passive, but the player is detected, switch to neutral behavior
            if (settings.behavior == EnemyBehavior.Passive)
            {
                SetBehavior(EnemyBehavior.Neutral);
            }
        }

        // Update behavior specific logic
        // Example: If the enemy is roaming, move randomly within a certain radius
        if (settings.behavior == EnemyBehavior.Passive)
        {
            // Example: Move randomly within a roaming radius
            Roam();
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            // Implement neutral behavior logic
        }
        else if (settings.behavior == EnemyBehavior.Aggressive)
        {
            // Implement aggressive behavior logic
        }
    }

    void SetBehavior(EnemyBehavior behavior)
    {
        settings.behavior = behavior;

        // Additional setup based on behavior
        // Example: Adjust agent speed or acceleration based on behavior
    }

    void Roam()
    {
        // Example: Move randomly within a roaming radius
        Vector3 randomDirection = Random.insideUnitSphere * settings.roamingRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, settings.roamingRadius, 1);
        Vector3 finalPosition = hit.position;
        agent.SetDestination(finalPosition);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
            playerLeveling.CheckForLevelUp(settings.exp);
            inventory.coins += settings.coins;
            pickupUI.DisplayPickup("XP", settings.exp);
            pickupUI.DisplayPickup("Coins", settings.coins);
        }
        else
        {
            // For now, we'll just print a message to the console
            Debug.Log("Enemy took " + damage + " damage. Current health: " + currentHealth);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}