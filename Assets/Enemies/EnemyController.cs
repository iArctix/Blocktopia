using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySettings settings;
    public Transform player;
    private NavMeshAgent navMeshAgent;
    private Vector3 originalPosition; // For passive behavior
    private Vector3[] waypoints; // Array to store generated waypoints
    private int currentWaypointIndex = 0; // Index of the current waypoint
    private bool isAttacking = false; // For neutral and aggressive behavior

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        originalPosition = transform.position; // Store the original position for passive behavior

        // Generate waypoints within the home region
        GenerateWaypoints();
    }

    void Update()
    {
        // Implement different behavior based on enemy settings
        switch (settings.behavior)
        {
            case EnemyBehavior.Passive:
                HandlePassiveBehavior();
                break;
            case EnemyBehavior.Neutral:
                HandleNeutralBehavior();
                break;
            case EnemyBehavior.Aggressive:
                HandleAggressiveBehavior();
                break;
        }
    }

    void HandlePassiveBehavior()
    {
        // If enemy is not attacking and player is within attack range, run away
        if (!isAttacking && Vector3.Distance(transform.position, player.position) <= settings.attackRange)
        {
            Vector3 moveDirection = transform.position - player.position;
            Vector3 newPos = transform.position + moveDirection.normalized * settings.attackRange;
            navMeshAgent.SetDestination(newPos);
        }
        // If enemy has moved far enough from player, return to original position
        else if (!isAttacking && Vector3.Distance(transform.position, originalPosition) >= settings.attackRange)
        {
            navMeshAgent.SetDestination(originalPosition);
        }
    }

    void HandleNeutralBehavior()
    {
        // If enemy is not attacking and player is within attack range, pursue player
        if (!isAttacking && Vector3.Distance(transform.position, player.position) <= settings.attackRange)
        {
            navMeshAgent.SetDestination(player.position);
        }
        // If enemy is not attacking and player is out of range, return to original position
        else if (!isAttacking && Vector3.Distance(transform.position, originalPosition) >= settings.attackRange)
        {
            navMeshAgent.SetDestination(originalPosition);
        }
    }

    void HandleAggressiveBehavior()
    {
        // If player is within detection range, chase player
        if (Vector3.Distance(transform.position, player.position) <= settings.detectionRange)
        {
            navMeshAgent.SetDestination(player.position);
        }
        // If player is out of range, roam
        else
        {
            Roam();
        }
    }

    void Roam()
    {
        // Check if the enemy has reached the current waypoint
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            // Set the next waypoint as the destination
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex]);
        }
    }

    void GenerateWaypoints()
    {
        // Generate random waypoints within the home region
        waypoints = new Vector3[settings.numWaypoints];
        for (int i = 0; i < settings.numWaypoints; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere * settings.homeRegionRadius;
            randomDirection += originalPosition;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, settings.homeRegionRadius, 1);
            waypoints[i] = hit.position;
        }

        // Set the first waypoint as the destination
        if (waypoints.Length > 0)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypointIndex]);
        }
    }

    // Called when the enemy is attacked
    public void TakeDamage(float damage)
    {
        // Reduce enemy's health by the amount of damage
        settings.maxHealth -= damage;

        // You can add additional logic here, such as checking if the enemy should die

        // For now, we'll just print a message to the console
        Debug.Log("Enemy took " + damage + " damage. Current health: " + settings.maxHealth);
    }
}