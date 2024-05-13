using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    private Transform player;
    private NavMeshAgent agent;
    private float currentHealth;
    private Vector3 homePosition;
    private bool isChasing = false;
    private bool isFleeing = false;
    private float attackCooldown = 0f; // Added attack cooldown

    // Reference to other scripts for XP, coins, and UI
    public PlayerLeveling playerLeveling;
    public InventoryData inventory;
    public PickupUI pickupUI;
    public EnemySpawner enemySpawner;

    [System.Obsolete]
    void Start()
    {
        currentHealth = settings.maxHealth;
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        homePosition = transform.position;

        playerLeveling = FindObjectOfType<PlayerLeveling>();
        pickupUI = FindObjectOfType<PickupUI>();
        enemySpawner = FindObjectOfType<EnemySpawner>();

        if (settings.behavior == EnemyBehavior.Passive)
        {
            Roam();
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            agent.SetDestination(homePosition);
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
            if (settings.behavior == EnemyBehavior.Neutral)
            {
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
            }
            else if (settings.behavior == EnemyBehavior.Passive)
            {
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
            }
            else if (settings.behavior == EnemyBehavior.Aggressive)
            {
                if (!agent.hasPath || agent.remainingDistance < 0.5f)
                {
                    Roam();
                }
                // Check if player is within detection range for aggressive enemies
                if (Vector3.Distance(transform.position, player.position) < settings.detectionRange)
                {
                    isChasing = true;
                }
            }
        }
        else
        {
            if (isChasing)
            {
                agent.SetDestination(player.position);
                // Check if player is within attack range and cooldown has elapsed
                if (Vector3.Distance(transform.position, player.position) <= settings.attackRange && attackCooldown <= 0f)
                {
                    Attack();
                }
            }
            else if (isFleeing)
            {
                agent.SetDestination(transform.position - (player.position - transform.position).normalized * settings.detectionRange);
            }

            if (Vector3.Distance(transform.position, player.position) > settings.detectionRange)
            {
                if (isChasing)
                {
                    isChasing = false;
                    Roam();
                }
                else if (isFleeing)
                {
                    isFleeing = false;
                    Roam();
                }
            }
        }

        if (attackCooldown > 0f)
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    void Attack()
    {
        // Perform attack on player
        player.GetComponent<PlayerHealth>().TakeDamage(settings.damage);
        // Reset attack cooldown
        attackCooldown = settings.attackCooldown;
    }

    void inrange()
    {
        if (settings.behavior == EnemyBehavior.Aggressive)
        {
            if (Vector3.Distance(transform.position, player.position) < settings.detectionRange)
            {
                isChasing = true;
            }
            else
            {
                isChasing = false;
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
            isFleeing = true;
        }
        else if (settings.behavior == EnemyBehavior.Neutral)
        {
            isChasing = true;
        }
    }

    void Die()
    {
        enemySpawner.EnemyDied(gameObject);
        Destroy(gameObject);
        playerLeveling.CheckForLevelUp(settings.exp);
        inventory.coins += settings.coins;
        pickupUI.DisplayPickup("XP", settings.exp);
        pickupUI.DisplayPickup("Coins", settings.coins);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, settings.detectionRange);
        Gizmos.DrawWireSphere(transform.position, settings.attackRange);
    }
}