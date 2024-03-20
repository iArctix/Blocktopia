using System;
using Unity.VisualScripting;
using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public GameObject levelRequirementUI; // Reference to the UI GameObject for displaying level requirement message
    public float reachDistance = 3f; // Adjust this value to change how far the player can interact with objects
    private float miningTime = 2f; // Time it takes to mine the ore

    bool isMining = false; // Flag to track if the player is currently mining
    float miningTimer = 0f; // Timer for mining duration
    OreShake currentShakingOre; // Reference to the OreShake script of the currently mined ore

    public Playerstats playerstats;
    public InventoryData InventoryData;
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
            animator.SetBool("IsActive", true); // Trigger the pickaxe animation

            // If not currently mining, start mining
            if (!isMining)
            {
                StartMining();
            }
            else
            {
                // Increment mining timer
                miningTimer += Time.deltaTime;

                // Check if mining time is reached
                if (miningTimer >= miningTime - (playerstats.GatherSpeedLevel / 10))
                {
                    CompleteMining();
                }
            }
        }
        else
        {
            animator.SetBool("IsActive", false); // Stop the pickaxe animation
            // If player releases mouse button, stop mining
            if (isMining)
            {
                StopMining();
            }
        }
    }

    void StartMining()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Ore"))
            {
                OreInstance oreInstance = hit.collider.GetComponent<OreInstance>();
                if (oreInstance != null)
                {
                    int oreLevelRequirement = oreInstance.oreData.toollevelrequirement;
                    if (CanMine(oreLevelRequirement))
                    {
                        isMining = true;

                        // Start shaking the ore
                        currentShakingOre = hit.collider.GetComponent<OreShake>();
                        if (currentShakingOre != null)
                        {
                            currentShakingOre.StartShaking(50f, 0.05f); // Adjust speed and amount as needed
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

    void StopMining()
    {
        // Hide level requirement UI
        levelRequirementUI.SetActive(false);

        isMining = false;
        miningTimer = 0f;

        // Stop shaking the ore
        if (currentShakingOre != null)
        {
            currentShakingOre.StopShaking();
            currentShakingOre = null;
        }
    }

    void CompleteMining()
    {
        // Hide level requirement UI
        levelRequirementUI.SetActive(false);

        // Perform raycasting to detect ore again
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Ore"))
            {
                OreInstance oreInstance = hit.collider.GetComponent<OreInstance>();
                if (oreInstance != null)
                {
                    int oreLevelRequirement = oreInstance.oreData.toollevelrequirement;
                    

                    
                    if (CanMine(oreLevelRequirement))
                    {
                        //Add item to inventory
                        if(oreInstance.oreData.Resourcename == "Copper")
                        {
                            InventoryData.Copper += 1;
                            pickupUI.DisplayPickup("Copper", 1);
                        }
                        else if (oreInstance.oreData.Resourcename == "Gold")
                        {
                            InventoryData.gold += 1;
                            pickupUI.DisplayPickup("Gold", 1);
                        }
                        else if(oreInstance.oreData.Resourcename == "Titanium")
                        {
                            InventoryData.titanium += 1;
                            pickupUI.DisplayPickup("Titanium", 1);
                        }
                        else
                        {
                            Debug.Log("SomethingBroke");
                        }
                      

                   


                        // Destroy the ore GameObject
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

        // Reset mining variables
        isMining = false;
        miningTimer = 0f;

        // Stop shaking the ore
        if (currentShakingOre != null)
        {
            currentShakingOre.StopShaking();
            currentShakingOre = null;
        }
    }

    bool CanMine(int oreLevelRequirement)
    {
        // Access player's pickaxe level from player's data
        int playerPickaxeLevel = playerstats.pickaxelevel;

        // Compare player's pickaxe level with ore's level requirement
        return playerPickaxeLevel >= oreLevelRequirement;
    }

   


     


}