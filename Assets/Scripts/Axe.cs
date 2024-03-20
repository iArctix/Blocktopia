using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public GameObject levelRequirementUI; // Reference to the UI GameObject for displaying level requirement message
    public float reachDistance = 3f; // Adjust this value to change how far the player can interact with objects
    private float choppingTime = 3f; // Time it takes to chop the wood

    bool isChopping = false; // Flag to track if the player is currently chopping
    float choppingTimer = 0f; // Timer for chopping duration
    OreShake currentShakingWood; // Reference to the WoodShake script of the currently chopped wood

    public Playerstats playerstats;
    public InventoryData inventoryData;
    public PickupUI pickupUI;

    void Start()
    {
        // Ensure the level requirement UI is turned off initially
        levelRequirementUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            levelRequirementUI.SetActive(false);
        }
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("IsActive", true); // Trigger the axe animation

            // If not currently chopping, start chopping
            if (!isChopping)
            {
                StartChopping();
            }
            else
            {
                // Increment chopping timer
                choppingTimer += Time.deltaTime;

                // Check if chopping time is reached
                if (choppingTimer >= choppingTime - (playerstats.GatherSpeedLevel / 10))
                {
                    CompleteChopping();
                }
            }
        }
        else
        {
            animator.SetBool("IsActive", false); // Stop the axe animation
            // If player releases mouse button, stop chopping
            if (isChopping)
            {
                StopChopping();
            }
        }
    }

    void StartChopping()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Wood"))
            {
                WoodInstance woodInstance = hit.collider.GetComponent<WoodInstance>();
                if (woodInstance != null)
                {
                    int woodLevelRequirement = woodInstance.woodData.toollevelrequirement;
                    if (CanChop(woodLevelRequirement))
                    {
                        isChopping = true;

                        // Start shaking the wood
                        currentShakingWood = hit.collider.GetComponent<OreShake>();
                        if (currentShakingWood != null)
                        {
                            currentShakingWood.StartShaking(50f, 0.05f); // Adjust speed and amount as needed
                        }
                    }
                    else
                    {
                        // Show level requirement UI
                        levelRequirementUI.SetActive(true);
                    }
                }
            }
        }
    }

    void StopChopping()
    {
        // Hide level requirement UI
        levelRequirementUI.SetActive(false);

        isChopping = false;
        choppingTimer = 0f;

        // Stop shaking the wood
        if (currentShakingWood != null)
        {
            currentShakingWood.StopShaking();
            currentShakingWood = null;
        }
    }

    void CompleteChopping()
    {
        // Hide level requirement UI
        levelRequirementUI.SetActive(false);

        // Perform raycasting to detect wood again
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Wood"))
            {
                WoodInstance woodInstance = hit.collider.GetComponent<WoodInstance>();
                if (woodInstance != null)
                {
                    int woodLevelRequirement = woodInstance.woodData.toollevelrequirement;
                    if (CanChop(woodLevelRequirement))
                    {
                        if(woodInstance.woodData.woodName == "Oak")
                        {
                            inventoryData.Oak += 1;
                            pickupUI.DisplayPickup("Oak", 1);

                        }
                        else if(woodInstance.woodData.woodName == "Birch")
                        {
                            inventoryData.Birch += 1;
                            pickupUI.DisplayPickup("Birch", 1);
                        }
                        else if(woodInstance.woodData.woodName == "Ash")
                        {
                            inventoryData.Ash += 1;
                            pickupUI.DisplayPickup("Ash", 1);
                        }
                        else
                        {
                            Debug.Log("Somethingbroke");
                        }

                        // Destroy the wood GameObject
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        // Show level requirement UI
                        levelRequirementUI.SetActive(true);
                    }
                }
            }
        }

        // Reset chopping variables
        isChopping = false;
        choppingTimer = 0f;

        // Stop shaking the wood
        if (currentShakingWood != null)
        {
            currentShakingWood.StopShaking();
            currentShakingWood = null;
        }
    }

    bool CanChop(int woodLevelRequirement)
    {
        // Access player's axe level from player's data
        int playerAxeLevel = playerstats.axelevel;

        // Compare player's axe level with wood's level requirement
        return playerAxeLevel >= woodLevelRequirement;
    }
}